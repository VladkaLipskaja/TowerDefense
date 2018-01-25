using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pauseUI;
    public void Opacity() { pauseUI.SetActive(true); Time.timeScale = 0f; }
    public void BackToGame() { Time.timeScale = 1f; pauseUI.SetActive(false); }
    public void Retry() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    public void Menu() { SceneManager.LoadScene(0); }
}
