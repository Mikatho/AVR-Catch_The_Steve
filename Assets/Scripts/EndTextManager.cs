using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextManager : MonoBehaviour
{
    public TMP_Text resultText;
    public TMP_Text finishedTime;

    public static bool winner;
    public static bool looser;

    private string winnerText = "Level finished!\nwidepeepoHappy";
    private string looserText = "You got caught, Dipshit!\nSadge";

    // Start is called before the first frame update
    void Start()
    {
        winner = false;
        looser = false;
    }

    // Update is called once per frame
    // Update, not FixedUpdate so it keeps updating when game is paused (even tho timeScale should not affect UI)
    void Update()
    {
        if (GameSceneManager.finished) {
            SetFinishedTime();
        }

        // Checks if player won or lost to set text message
        if (winner) {
            resultText.text = winnerText;
        } else if (looser) {
            resultText.text = looserText;
        }
    }

    // Sets finished gametime in endscreen
    public void SetFinishedTime()
    {
        finishedTime.text = InGameTimer.formatedTime;
    }
}
