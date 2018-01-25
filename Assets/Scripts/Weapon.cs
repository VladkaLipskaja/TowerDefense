using UnityEngine;

public class Weapon : MonoBehaviour {

    private Transform target;
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform rotateForBullet;
    public float turnSpped =10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start () { InvokeRepeating("UpdateWeapon", 0f, 0.5f); }

    void UpdateWeapon() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) target = nearestEnemy.transform;
        else target = null;
    }
	
	void Update () {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        Quaternion aroundRotation = Quaternion.LookRotation(direction);
        Vector3 rotation =Quaternion.Lerp(rotateForBullet.rotation,aroundRotation, Time.deltaTime*turnSpped).eulerAngles;
        rotateForBullet.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f) { Shoot(); fireCountDown = 1f / fireRate; }
        fireCountDown -= Time.deltaTime;
	}

    void Shoot() {
       GameObject bulletGo =(GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null) bullet.Seek(target);
    }

    private void OnDrawGizmosSelected() { Gizmos.color = Color.red; Gizmos.DrawWireSphere(transform.position, range); }
}
