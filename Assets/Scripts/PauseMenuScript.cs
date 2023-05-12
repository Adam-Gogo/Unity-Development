using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject PauseButton;
    [SerializeField]
    GameObject PauseMenu;

    public void PauseGame()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
