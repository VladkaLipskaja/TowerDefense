using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutUI;
    private void Start() { if (PlayerPrefs.HasKey("UnlockedLevel")) LevelButtons.NumberOfUnlocked = PlayerPrefs.GetInt("UnlockedLevel"); else PlayerPrefs.SetInt("UnlockedLevel", 0); }

    public void NewGame() {
        PlayerPrefs.SetInt("UnlockedLevel", 0);
        SceneManager.LoadScene(1); }

    public void Continue()  { SceneManager.LoadScene(1); }
    public void Exit()      { Application.Quit(); }
    public void About()     { aboutUI.SetActive(true); }
    public void AboutExit() { aboutUI.SetActive(false); }
}
