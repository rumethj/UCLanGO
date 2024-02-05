using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;

public class QrCodeRecenter : MonoBehaviour
{
    [SerializeField]
    private ARSession session;
    [SerializeField]
    private ARSessionOrigin sessionOrigin;
    [SerializeField]
    private ARCameraManager cameraManager;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader();

    private void Update()
    {
        // FOR DEBUG ONLY
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetQrCodeRecenterTarget("Room404");
        }
    }

    private void OnEnable()
    {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            return;
        }

        var conversionParams = new XRCpuImage.ConversionParams
        {
            // Get entire image
            inputRect = new RectInt(0, 0, image.width,image.height),

            // Downsample by 2
            outputDimensions = new Vector2Int(image.width / 2, image.height / 2),

            //Choose RGBA format
            outputFormat = TextureFormat.RGBA32,

            // Flip along verticle axis
            transformation = XRCpuImage.Transformation.MirrorY
        };

        // See how many bytes you need to store the final image
        int size = image.GetConvertedDataSize(conversionParams);

        // Allocate a buffer to store the image
        var buffer = new NativeArray<byte>(size, Allocator.Temp);

        // Extract Image Data
        image.Convert(conversionParams, buffer);

        // dispose of the XRCpuImage because we already converted the image to RGBA32 and wrote it into the buffer
        image.Dispose();

        // Apply to texture for visualization
        cameraImageTexture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false);

        cameraImageTexture.LoadRawTextureData(buffer);
        cameraImageTexture.Apply();

        // Dispose of temp buffer
        buffer.Dispose();

        // Decode barcode in bitmap
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        if (result != null)
        {
            SetQrCodeRecenterTarget(result.Text);
        }

    }


    private void SetQrCodeRecenterTarget(string targetText)
    {
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(targetText));
        if (currentTarget != null)
        {
            // Reset position and rotation of ARSession
            session.Reset();
     

            // Add offset for recentering
            sessionOrigin.transform.position = currentTarget.PositionObject.transform.position;
            sessionOrigin.transform.rotation = currentTarget.PositionObject.transform.rotation;
        }

        PlayerPrefs.SetInt("isQrScanned", 1);
        PlayerPrefs.Save();
        Debug.Log("QR scan set to: " + PlayerPrefs.GetInt("isQrScanned"));
    }

    // FOR DEBUGGING ONLY
    public void TeleportLocation(string inputLocation)
    { 
        SetQrCodeRecenterTarget(inputLocation);
    }

}
// FireDragonGameStudio(2022b) 02 / 05 - ARFoundation indoor - navigation - NO cloudanchor, NO ARPointCloud, (almost) NO coding! Youtube. Available at: https://www.youtube.com/watch?v=C7TNBybSOq0.