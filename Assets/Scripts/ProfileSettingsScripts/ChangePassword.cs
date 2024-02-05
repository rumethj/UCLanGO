using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChangePassword : MonoBehaviour
{
    public InputField oldPassword;
    public InputField newPassword;
    public InputField confirmNewPassword;
    public Button changePwButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerifyInputs()
    {
        changePwButton.interactable = (
            oldPassword.text.Length >= 1
            && newPassword.text.Length >= 1
            && confirmNewPassword.text.Length >= 1
            && oldPassword.text == PlayerPrefs.GetString("userPassword")
            && newPassword.text == confirmNewPassword.text);
    }

    public void SaveNewPasswordDetails()
    {
        if (oldPassword.text.Length >= 1
            && newPassword.text.Length >= 1
            && confirmNewPassword.text.Length >= 1
            && oldPassword.text == PlayerPrefs.GetString("userPassword")
            && newPassword.text == confirmNewPassword.text)
        {
            PlayerPrefs.SetString("userPassword", newPassword.text);
            PlayerPrefs.Save();

            GoTo.Login();
        }
        
    }
}
