using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameTimer : MonoBehaviour
{
    public static string formatedTime;

    public TMP_Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Weird ass math stuff
        float t = Time.time - startTime;

        int minutes = ((int) t / 60);
        int seconds = ((int) t);

        if (seconds >= 60) {
            seconds -= 60;
        }

        float millis = ((t * 1000) % 1000);

        //Format millis to 2 digits
        int formatedMillis = (int) millis / 10;

        if (formatedMillis == 100) {
            formatedMillis = 0;
        }

        // Just some damn nice formatting of the time
        formatedTime = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, formatedMillis);

        timerText.text = formatedTime;
    }
}
