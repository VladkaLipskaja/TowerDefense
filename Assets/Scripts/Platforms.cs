using UnityEngine;

public class Platforms : MonoBehaviour {
    public Color chosenColor;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject weapon;

    private Renderer rent;
    private Color beginColor;

    BuildManager buildManager;

	void Start () {
        rent = GetComponent<Renderer>();
        beginColor = rent.material.color;
        buildManager = BuildManager.instance; }

    private void OnMouseDown() { 
        if (!buildManager.CanBuild) return;
        if (weapon != null) return;
        buildManager.BuildWeapon(this);}

    void OnMouseEnter () {
        if (!buildManager.CanBuild) return;
        if (buildManager.EnoughMoney) rent.material.color = chosenColor;
        else rent.material.color = notEnoughMoneyColor;	}

    void OnMouseExit() { rent.material.color = beginColor; }
}
