using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject pausepanel;
    public GameObject pausebutton;
    public void Play()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PauseMenuBehaviour()
    {
        pausepanel.SetActive(true);
        pausebutton.SetActive(false);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pausepanel.SetActive(false);
        pausebutton.SetActive(true);
        Time.timeScale = 1;
    }
    public void MenuMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
