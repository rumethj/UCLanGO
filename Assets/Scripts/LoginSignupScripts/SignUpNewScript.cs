using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class SignUpNewScript : MonoBehaviour
{
    public InputField email;
    public InputField userName;
    public InputField password;
    public InputField confirmPassword;
    public InputField disability;
    public Button signUpButton;

    private void Start()
    {
        signUpButton.interactable = false;
    }

    public void VerifyInputs()
    {
        signUpButton.interactable = (userName.text.Length >= 3
            && password.text.Length >= 3
            && email.text.Length >= 9
            && disability.text.Length >= 1
            && (password.text == confirmPassword.text));
    }

    public void SaveUserDetails()
    {


        PlayerPrefs.SetString("userEmail", email.text);
        PlayerPrefs.SetString("userName", userName.text);
        PlayerPrefs.SetString("userPassword", password.text);
        PlayerPrefs.SetString("userDisability", disability.text);
        PlayerPrefs.Save();

        Debug.Log(PlayerPrefs.GetString("userEmail"));
        Debug.Log(PlayerPrefs.GetString("userName"));
        Debug.Log(PlayerPrefs.GetString("userPassword"));
        Debug.Log(PlayerPrefs.GetString("userDisability"));

        GoTo.Login();
    }


}
