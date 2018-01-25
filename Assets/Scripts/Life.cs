using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    public Text livesText;
	void Update () { livesText.text = PlayerData.Lives.ToString() + " LIVES"; }
}
