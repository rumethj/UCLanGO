using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    public TMP_Text displayNameText;
    public TMP_Text displaySummaryText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("ValuePass") == "Rooftop")
        {
            displayNameText.text = "Rooftop";
            displaySummaryText.text = "A place where you can relax, catch up with friends and play some pool.";
        }
        else if (PlayerPrefs.GetString("ValuePass") == "Cafeteria")
        {
            displayNameText.text = "Cafeteria";
            displaySummaryText.text = "Want breakfast, lunch or a snack? We've got you. ";
        }
        else if (PlayerPrefs.GetString("ValuePass") == "Library")
        {
            displayNameText.text = "Library";
            displaySummaryText.text = "A quiet spot to work on assignments, or to catch up on your favourite book.";

        }
        else if (PlayerPrefs.GetString("ValuePass") == "Lobby")
        {
            displayNameText.text = "Lobby";
            displaySummaryText.text = "If you need any help or information about the university, this is where you need to be. ";
        }
        else if (PlayerPrefs.GetString("ValuePass") == "Car Park")
        {
            displayNameText.text = "Car Park";
            displaySummaryText.text = "Want to park your vehicle? This is the place you are looking for.";
        }
        else if (PlayerPrefs.GetString("ValuePass") == "Students Lounge")
        {
            displayNameText.text = "Students Lounge";
            displaySummaryText.text = "If you want you to wind down after a lecture or discuss work with your friends, this is the perfect hangout spot.";
        }
        else if (PlayerPrefs.GetString("ValuePass") == "Teachers Lounge")
        {
            displayNameText.text = "Teachers Lounge";
            displaySummaryText.text = "Head this way if you want to clear any doubts or ask questions from your lecturers.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
