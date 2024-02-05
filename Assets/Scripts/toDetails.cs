using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toDetails : MonoBehaviour
{
    public string valuePass = "Cafeteria";
    public void moveScene()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("ValuePass", valuePass);
        GoTo.Details();
    }
}





