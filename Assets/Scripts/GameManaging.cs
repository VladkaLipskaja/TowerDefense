using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManaging : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject winLevelUI;

    private int level;

    private void Start() { Time.timeScale = 1f; GameIsOver = false; }
    void Update() {
        if (GameIsOver) return;
        if (PlayerData.Lives <= 0) EndOfGame();
        else if (Control.EnemyAlive == 0 && Control.AllWavesAreEnded) WinLevel(); }

    void EndOfGame() {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; }

    void WinLevel() {
        int.TryParse(SceneManager.GetActiveScene().name, out level);
        if (PlayerPrefs.GetInt("UnlockedLevel") < level) PlayerPrefs.SetInt("UnlockedLevel", level); 
        winLevelUI.SetActive(true);
        Time.timeScale = 0f; }
}
