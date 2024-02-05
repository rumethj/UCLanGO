using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toPathway : MonoBehaviour
{
    public void moveScene()
    {
        if (PlayerPrefs.GetString("ValuePassed") == "401")
        {
            PlayerPrefs.SetString("SelectedDestination", "Room401"); // Save selected destination to PlayerPrefs
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetString("ValuePassed") == "402")
        {
            PlayerPrefs.SetString("SelectedDestination", "Room402"); // Save selected destination to PlayerPrefs
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetString("ValuePassed") == "403")
        {
            PlayerPrefs.SetString("SelectedDestination", "Room403"); // Save selected destination to PlayerPrefs
            PlayerPrefs.Save();
        }
        else if (PlayerPrefs.GetString("ValuePassed") == "404")
        {
            PlayerPrefs.SetString("SelectedDestination", "Room404"); // Save selected destination to PlayerPrefs
            PlayerPrefs.Save();
        }

        GoTo.ArNavigation();
    }
}
