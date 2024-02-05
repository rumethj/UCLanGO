using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.SceneManagement;

public class FirebaseEventRead : MonoBehaviour
{
    FirebaseFirestore db;
    private Firebase.FirebaseApp app;
    
    public TMP_Text displayHostText;
    public TMP_Text displayModuleText;
    public TMP_Text displayProgramText;
    public TMP_Text displayStartTimeText;
    public TMP_Text displayEndTimeText;

    void Start()
    {
        string classroom = PlayerPrefs.GetString("ValuePassed", "DefaultFallbackValue");

        Debug.Log("Value passed: " + classroom);

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;

            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                app = Firebase.FirebaseApp.DefaultInstance;
                db = FirebaseFirestore.GetInstance(app);

                // Call a method to read data
                ReadDataFromFirestore(classroom);
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    void ReadDataFromFirestore(string classroom)
    {
        CollectionReference agileCollection = db.Collection("Event");

        string documentIdToRetrieve = classroom;

        DocumentReference documentRef = agileCollection.Document(documentIdToRetrieve);

        documentRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error getting document: " + task.Exception);
                return;
            }

            DocumentSnapshot document = task.Result;

            if (document.Exists)
            {
                Dictionary<string, object> userData = document.ToDictionary();

                string endTime = userData["endTime"].ToString();
                string host = userData["host"].ToString();
                string module = userData["module"].ToString();
                string program = userData["program"].ToString();
                string startTime = userData["startTime"].ToString();
                

                string displayHost = $"{host}";
                string displayModule = $"{module}";
                string displayProgram = $"{program} ";
                string displayStartTime = $"{startTime}";
                string displayEndTime = $"{endTime}";

                if (displayHostText != null)
                {
                    displayHostText.text = displayHost;
                }

                if (displayModuleText != null)
                {
                    displayModuleText.text = displayModule;
                }

                if (displayProgramText != null)
                {
                    displayProgramText.text = displayProgram;
                }

                if (displayStartTimeText != null)
                {
                    displayStartTimeText.text = displayStartTime;
                }
                if (displayEndTimeText != null)
                {
                    displayEndTimeText.text = displayEndTime;
                }


                Debug.Log(displayHostText);
                Debug.Log(displayModuleText);
                Debug.Log(displayProgramText);
                Debug.Log(displayStartTimeText);
                Debug.Log(displayEndTimeText);
            }
            else
            {
                Debug.Log("Document does not exist!");
            }
        });
    }
}
