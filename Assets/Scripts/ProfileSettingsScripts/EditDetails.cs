using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EditDetails : MonoBehaviour
{
    public InputField newUsername;
    public InputField newEmail;
    public InputField newDisability;
    public Button changeDetailsButton;

    //public void VerifyInputs()
    //{
    //    changeDetailsButton.interactable = (
    //        newUsername.text.Length >= 1
    //        && newEmail.text.Length >= 1
    //        && confirmNewPassword.text.Length >= 1
    //}

    public void SaveNewUserDetails()
    {
        

        if (!string.IsNullOrEmpty(newUsername.text))
        {
            PlayerPrefs.SetString("userName", newUsername.text); 
        }

        if (!string.IsNullOrEmpty(newEmail.text))
        {
            PlayerPrefs.SetString("userEmail", newEmail.text);
        }

        if (!string.IsNullOrEmpty(newDisability.text))
        {
            PlayerPrefs.SetString("userDisability", newDisability.text);
        }

        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("userEmail"));
        Debug.Log(PlayerPrefs.GetString("userName"));
        Debug.Log(PlayerPrefs.GetString("userPassword"));
        Debug.Log(PlayerPrefs.GetString("userDisability"));

        GoTo.UserDetails();

    }
}
