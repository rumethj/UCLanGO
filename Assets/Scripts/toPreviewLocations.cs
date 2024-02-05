using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toPreviewLocations : MonoBehaviour
{
    public string valuePassed = "401";
    public void moveScene()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("ValuePassed", valuePassed);
        GoTo.PreviewLocation();
    }
}
