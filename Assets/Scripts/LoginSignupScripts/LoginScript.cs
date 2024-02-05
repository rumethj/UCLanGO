
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

    public InputField userName;
    public InputField password;
    public Button loginButton;

    private void Start()
    {
        loginButton.interactable = false;
    }

    public void VerifyInputs()
    {
        loginButton.interactable = userName.text == PlayerPrefs.GetString("userName")
            && password.text == PlayerPrefs.GetString("userPassword");
    }

    public void LoginUserToHome()
    {
        GoTo.Home();
    }
    
}








