using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{
    // Start is called before the first frame update
    public static void PreviewLocation()
    {
        SceneManager.LoadScene("Preview Locations");
    }

    public static void ProfilePage()
    {
        SceneManager.LoadScene("userDetailsPage");
    }

    public static void SitesOfInterest()
    {
        SceneManager.LoadScene("SitesOfInterest");
    }

    public static void Details()
    {
        SceneManager.LoadScene("Details");
    }

    public static void UserDetails()
    {
        SceneManager.LoadScene("userDetailsPage");
    }

    public static void ChangePassword()
    {
        SceneManager.LoadScene("change_password");
    }

    public static void ChangeDetails()
    {
        SceneManager.LoadScene("edit_details");
    }

    public static void Home()
    {
        SceneManager.LoadScene("HomePage");
    }

    public static void SignUp()
    {
        SceneManager.LoadScene("SignUpNewScene");
    }

    public static void Login()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public static void ArNavigation()
    {
        SceneManager.LoadScene("ARScene");
    }

}
