using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine.UI;
using Firebase.Storage;
using TMPro;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
public class FirebaseRoomRead : MonoBehaviour
{
    FirebaseFirestore db;
    private Firebase.FirebaseApp app;
    public TMP_Text displayHallText;
    public TMP_Text displayFloorText;

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
        CollectionReference agileCollection = db.Collection("Room");

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

                string floor = userData["floor"].ToString();

                string displayHall = $"Lecture Hall {document.Id}";
                string displayFloor = $"{floor} floor";

                if (displayHallText != null)
                {
                    displayHallText.text = displayHall;
                }

                if (displayFloorText != null)
                {
                    displayFloorText.text = displayFloor;
                }

                Debug.Log(displayHallText);
                Debug.Log(displayFloorText);
            }
            else
            {
                Debug.Log("Document does not exist!");
            }
        });
    }
    
}

