using UnityEngine;

public class Shop : MonoBehaviour {
    public WeaponAttributes itemWeapon1Prefab;
    public WeaponAttributes itemWeapon2Prefab;
    public WeaponAttributes itemWeapon3Prefab;

    BuildManager buildManager;
   void Start() { buildManager = BuildManager.instance; }

    public void SelectItem1() { buildManager.SetWeaponSelected(itemWeapon1Prefab); }
    public void SelectItem2() { buildManager.SetWeaponSelected(itemWeapon2Prefab); }
    public void SelectItem3() { buildManager.SetWeaponSelected(itemWeapon3Prefab); }
}

