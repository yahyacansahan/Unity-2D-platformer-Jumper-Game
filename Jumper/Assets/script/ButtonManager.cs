using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public AudioMixer audiomixer;

    public GameObject pauseMenu;

    public void startGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void home()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void pause()
    {
        if (GameIsPaused == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void resume()
    {
        if (GameIsPaused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }

    public void setVolume(float volume)
    {
        Debug.Log("volume");
        audiomixer.SetFloat("volume", volume);
    }



}
