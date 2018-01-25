using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour {
    public int level;

    public static int NumberOfUnlocked=0;
    public Color32 buttonUnlockedTextColor = new Color32(201,146,1,255);
    public Color32 buttonCurrentTextColor  = new Color32(255,255,255,255);
    public Color32 buttonLockedTextColor   = new Color32(51,28,0,227);
    public Button[] allButtons;

    void Start()
    {
        NumberOfUnlocked = PlayerPrefs.GetInt("UnlockedLevel");

        for (int i = 0; i < NumberOfUnlocked; i++) allButtons[i].GetComponentInChildren<Text>().color = buttonUnlockedTextColor;
        allButtons[NumberOfUnlocked].GetComponentInChildren<Text>().color = buttonCurrentTextColor;
        for (int i = NumberOfUnlocked+1; i < allButtons.Length; i++) {
            allButtons[i].GetComponentInChildren<Text>().color = buttonLockedTextColor;
            allButtons[i].interactable = false;} }

    public void LoadLevel(int level) { SceneManager.LoadScene(level); }
}
