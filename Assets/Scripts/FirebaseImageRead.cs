using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FirebaseImageRead : MonoBehaviour
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
        string location = PlayerPrefs.GetString("ValuePass", "DefaultFallbackValue");

        Debug.Log("Value passed: " + location);

        if (location == "Cafeteria")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Cafeteria%201.jpeg?alt=media&token=9cd77d71-d0d5-4cf2-a486-41a179e50f85"));
        }
        else if (location == "Car Park")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Car%20Park%202.jpeg?alt=media&token=04704050-b18f-49dd-b27f-55a7d0446221"));
        }
        else if (location == "Library")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Library%201.jpeg?alt=media&token=61437aa3-1cbf-4b36-b985-8cb162b5b0e1"));
        }
        else if (location == "Lobby")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Lobby%202.jpeg?alt=media&token=9d64c101-cfcf-4d48-b022-665fd949cefa"));
        }
        else if (location == "Rooftop")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Rooftop%202.jpeg?alt=media&token=12ff04aa-93fb-4e33-b7ee-0133c58bb0f2"));
        }
        else if (location == "Students Lounge")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Student's%20lounge%201.jpeg?alt=media&token=f4c92070-3c14-4cbb-9aa8-df561a9da0c6"));
        }
        else if (location == "Teachers Lounge")
        {
            StartCoroutine(LoadImage("https://firebasestorage.googleapis.com/v0/b/test123-f4d2f.appspot.com/o/Teacher's%20lounge%201.jpeg?alt=media&token=5c97a521-5bb1-4553-8aa8-5f4b29a2433a"));

        }


    }

    private void Update()
    {

    }

};

    



