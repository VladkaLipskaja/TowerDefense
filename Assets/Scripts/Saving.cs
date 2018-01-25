using UnityEngine;

public class Saving : MonoBehaviour {
    void OnApplicationQuit() { PlayerPrefs.SetInt("UnlockedLevel", LevelButtons.NumberOfUnlocked); }
}
