using UnityEngine.UI;
using UnityEngine;

public class MoneyText : MonoBehaviour {
    public Text moneyText;
	void Update () { moneyText.text ="$"+ PlayerData.Money.ToString(); }
}
