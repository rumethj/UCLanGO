using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DestinationSelectionSceneController : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    
    private string selectedText;

    private void Start()
    {
        selectedText = navigationTargetDropDown.options[0].text; // default location
    }

    // Change location on drop down menu selection
    public void SetCurrentNavigationTarget(int selectedValue)
    {
        selectedText = navigationTargetDropDown.options[selectedValue].text;
    }

    // Set location on click
    public void StartARNavigation()
    {
        PlayerPrefs.SetString("SelectedDestination", selectedText); // Save selected destination to PlayerPrefs
        PlayerPrefs.Save();

        // Load AR scene
        SceneManager.LoadScene("ARScene");
    }
}
