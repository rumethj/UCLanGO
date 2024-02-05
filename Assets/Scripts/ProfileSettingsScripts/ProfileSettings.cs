using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ProfileSettings : MonoBehaviour
{
    public TMP_Text emailText;
    public TMP_Text userNameText;
    public TMP_Text disabilityText;

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("userEmail"));
        Debug.Log(PlayerPrefs.GetString("userName"));
        Debug.Log(PlayerPrefs.GetString("userPassword"));
        Debug.Log(PlayerPrefs.GetString("userDisability"));

        emailText.text = PlayerPrefs.GetString("userEmail");
        userNameText.text = PlayerPrefs.GetString("userName");
        disabilityText.text = PlayerPrefs.GetString("userDisability");
    }
}
