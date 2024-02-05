using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RoomImage2 : MonoBehaviour
{
    RawImage displayImage;
    IEnumerator LoadImage(string imageUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
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

        if (classroom == "401")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/401-2.jpeg?alt=media&token=f029686b-99ac-4cb2-bf4a-bb1504d08044"));
        }
        else if (classroom == "402")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/402-2.jpeg?alt=media&token=089ee3ea-7ff4-4ee0-9a92-ee25b11f8a58"));
        }
        else if (classroom == "403")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/403-2.jpg?alt=media&token=c734c546-c505-4346-9126-8bf740f443c2"));
        }
        else if (classroom == "404")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/404-2.jpg?alt=media&token=17338c09-df60-4f16-a9f9-9865049db16b"));
        }
        else if (classroom == "405")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/405-2.jpg?alt=media&token=488efd5a-0452-4ac3-b9bc-cd225554a6c8"));
        }
        else if (classroom == "406")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/406-2.jpg?alt=media&token=69c7cbee-ce95-44f3-b839-3e4361aee952"));
        }
        else if (classroom == "407")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/407-2.jpg?alt=media&token=cab17081-91ec-4c09-9c43-90eab03dc57c"));
        }
        else if (classroom == "408")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/408-2.jpeg?alt=media&token=4c16f464-9d9d-49b8-979a-006782708c3e"));
        }

    }

    private void Update()
    {

    }

}


