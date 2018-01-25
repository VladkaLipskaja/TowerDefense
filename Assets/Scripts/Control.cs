using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public static int EnemyAlive;
    public static bool AllWavesAreEnded;

    public  Transform[] allEnemiesPrefabs = new Transform[9];
    public Transform point;
    public Text textCountDown;

    private float countDown = 2f;
    private int number = 0;
    private int level;
    private int wave;

    void Start() {
        EnemyAlive = 0;
        AllWavesAreEnded = false;
        int.TryParse(SceneManager.GetActiveScene().name, out level);
        wave = level * 7 + (level - 1) * 3; }

    void Update() {
        if (countDown <= 0f) {
            if (--wave >= 0) StartCoroutine(Enemy()); else AllWavesAreEnded = true;
            countDown = 5; }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        if (AllWavesAreEnded) textCountDown.text = ""; else  textCountDown.text = string.Format("{0:00.00}",countDown); }

    IEnumerator Enemy() {
        number = Random.Range(2, 8);
        PlayerData.Rounds++;
        for (int i = 0; i < number; i++) { CreateEnemy(); yield return new WaitForSeconds(0.5f); } }

    void CreateEnemy() { EnemyAlive++; Instantiate(allEnemiesPrefabs[Random.Range(0, level + 7)]); }
}
