using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject musicSlider;

    public AudioSource musicSource;

    public static float musicVol = 1f;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.GetComponent<Slider>().value = musicVol;
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.volume = 0.4f * musicVol;
    }

    public void StartGame() {
        // Setting variables to determine which state of game the player is
        GameSceneManager.paused = false;
        GameSceneManager.finished = false;
        if (!GameSceneManager.paused) {
            // TimeScale = 0 -> Pauses updates and game
            // TimeScale = 1 -> Continues updates and game in normal speed
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
        Cursor.visible = false;
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void ChangeVolume() {
        musicVol = musicSlider.GetComponent<Slider>().value;
    }
}
