using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RoomImage1 : MonoBehaviour
{
    RawImage displayImage;
    IEnumerator LoadImage(string imageUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture. GetTexture(imageUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            displayImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }

    }

    void Start()
    {
        displayImage = gameObject.GetComponent<RawImage>();
        string classroom = PlayerPrefs.GetString("ValuePassed", "DefaultFallbackValue");

        Debug.Log("Value passed: " + classroom);

        if (classroom=="401")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/401-1.jpeg?alt=media&token=9648b344-8f3f-4293-9626-e6bcaa8b818e"));
        }
        else if (classroom == "402")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/402-1.jpeg?alt=media&token=18c0567e-19a0-49a8-b75c-a8e94d76b570"));
        }
        else if (classroom == "403")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/403-1.jpg?alt=media&token=b3418830-d03a-4cf0-b1d4-2aea845d5a63"));
        }
        else if (classroom == "404")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/404-1.jpg?alt=media&token=d94faff8-8912-4602-984e-31c7c8b77566"));
        }
        else if (classroom == "405")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/405-2.jpg?alt=media&token=488efd5a-0452-4ac3-b9bc-cd225554a6c8"));
        }
        else if (classroom == "406")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/406-1.jpeg?alt=media&token=6417d5a2-0b44-4202-949a-f803dedb71a4"));
        }
        else if (classroom == "407")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/407-1.jpg?alt=media&token=c8a6a25d-8bd6-4c23-86b3-eb027b0b74d4"));

        }
        else if (classroom == "408")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/408-1.jpeg?alt=media&token=8a2a10bb-ed79-4968-a4e2-cfd488fdd2ca"));
        }


    }

    private void Update()
    {
        
    }

}

