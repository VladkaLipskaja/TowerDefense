using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour {
    public Text roundsText;
    void OnEnable() { roundsText.text = PlayerData.Rounds.ToString(); }
    public void Continue() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); }
    public void Menu() { SceneManager.LoadScene(0); }
}
