using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject effectForShooting;

    private Transform target;

    public float speed = 70f;
    public int damage = 50;   

    public void Seek(Transform _target) {  target = _target; }

	void Update () {
        if (target == null) { Destroy(gameObject); return; }

        Vector3 direction = target.position - transform.position;
        float distanceForFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceForFrame) { HitTarget(); return; }
        transform.Translate(direction.normalized * distanceForFrame, Space.World);
    }

    void HitTarget() {
        GameObject effects = (GameObject)Instantiate(effectForShooting, transform.position, transform.rotation);
        Destroy(effects, 2f);
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null) { e.HealthEnemyDamage(damage); }
    } 
}
