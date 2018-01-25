using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake() {
        if (instance != null) return;
        instance = this;}

    public GameObject itemWeapon1;
    public GameObject itemWeapon2;
    public GameObject itemWeapon3;

    public GameObject buifdEffect;

    private WeaponAttributes weaponToBuild;

    public bool CanBuild { get { return weaponToBuild != null; } }
    public bool EnoughMoney { get { return PlayerData.Money>= weaponToBuild.cost; } }

    public void BuildWeapon(Platforms platforms) {
        if (PlayerData.Money < weaponToBuild.cost) return;

        PlayerData.Money -= weaponToBuild.cost;
        GameObject weaponCreated = (GameObject)Instantiate(weaponToBuild.prefab, platforms.transform.position, Quaternion.identity);
        if (weaponToBuild.prefab.name != "Tower Mage") weaponCreated.transform.rotation =Quaternion.Euler(-90f,0f,0f);

        platforms.weapon = weaponCreated;
        GameObject effectOfBuilding = (GameObject)Instantiate(buifdEffect, platforms.transform.position, Quaternion.identity);
        Destroy(effectOfBuilding, 5f); }

    public void SetWeaponSelected(WeaponAttributes weapon) { weaponToBuild = weapon; }
}
