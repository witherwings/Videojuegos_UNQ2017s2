using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 500;

	public static int Lives;
	public int startLives = 20;

	public static int Waves;
	public static int KillCountRound;
	public static int KillCountTotal;

	void Start(){
		Money = startMoney;
		Lives = startLives;

		if (PersistenceScript.Instance.hardMode) {
			Money = PersistenceScript.Instance.money;
			Lives = PersistenceScript.Instance.lives;
		}

		Waves = 0;
		KillCountRound = 0;
	}
}
