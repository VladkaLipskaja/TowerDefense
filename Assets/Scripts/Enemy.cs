using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int startHealth = 100;
    public int value = 50;
    private int checkpointIndex = 0;
    private int health;

    public GameObject enemyDeatheffect;
    public Image healthBar;
    private Transform target;

	void Start () { health = startHealth; target = Checkpoints.points[0]; }

    public void HealthEnemyDamage (int minusHealth) {
        health -= minusHealth;
        healthBar.fillAmount = health/startHealth;
        if (health <= 0) EnemyDeath(); }

    void EnemyDeath() {
        PlayerData.Money += value;
        Control.EnemyAlive--;
        GameObject effect = (GameObject)Instantiate(enemyDeatheffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
        Destroy(gameObject); }

    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) GetNextCheckPoint(); }

    void GetNextCheckPoint() {
        if (++checkpointIndex >= Checkpoints.points.Length) { EndOfWay();  return; }
        transform.Rotate(0, 90 * Mathf.Sign(target.rotation.y), 0);
        target = Checkpoints.points[checkpointIndex]; }

    void EndOfWay() {
        PlayerData.Lives--;
        Control.EnemyAlive--;
        Destroy(gameObject);
    }
}
