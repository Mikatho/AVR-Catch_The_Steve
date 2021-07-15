using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameSceneManager : MonoBehaviour
{
    public AudioSource musicSource;

    public VideoPlayer video;

    public GameObject musicSliderPause;
    public GameObject musicSliderEnd;

    public GameObject player;

    public GameObject pauseMenu;
    public GameObject endMenu;

    public static bool paused;
    public static bool finished;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        finished = false;
        
        //Setting menus not active/visible at start
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);

        musicSliderPause.GetComponent<Slider>().value = MenuSceneManager.musicVol;
        musicSliderEnd.GetComponent<Slider>().value = MenuSceneManager.musicVol;
    }

    // Update is called once per frame
    // Update, not FixedUpdate so you can do things when game paused
    void Update() {

        musicSource.volume = 0.4f * MenuSceneManager.musicVol;

        // Weird ass ifs to check what state of game the player is
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused && !finished) {
                PauseGame ();
            } else if (paused) {
                ResumeGame ();
            }
        }

        if (finished) {
            EndGame();
        }
    }

    public void StartGame() {
        paused = false;
        finished = false;
        if (!paused) {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
        Cursor.visible = false;
    }

    public void PauseGame() {
        paused = true;
        if (paused) {
            Time.timeScale = 0f;
            video.Pause();
            pauseMenu.SetActive(true);
        }
        Cursor.visible = true;
    }

    public void ResumeGame() {
        paused = false;
        if (!paused) {
            Time.timeScale = 1f;
            video.Play();
            pauseMenu.SetActive(false);
        }
        Cursor.visible = false;
    }

    public void EndGame() {
        Time.timeScale = 0f;
        video.Pause();
        endMenu.SetActive(true);
        Cursor.visible = true;
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void ChangeVolumePause() {
        MenuSceneManager.musicVol = musicSliderPause.GetComponent<Slider>().value;

        musicSliderEnd.GetComponent<Slider>().value = MenuSceneManager.musicVol;
    }

    public void ChangeVolumeEnd() {
        MenuSceneManager.musicVol = musicSliderEnd.GetComponent<Slider>().value;

        musicSliderPause.GetComponent<Slider>().value = MenuSceneManager.musicVol;
    }
}
