using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static int Money;
    public static int Rounds;
    public static int Lives;
    public int atBeginLives=10;
    public int atBeginMoney = 600;

    void Start() {
        Money = atBeginMoney;
        Lives = atBeginLives;
        Rounds = 0; }
}
