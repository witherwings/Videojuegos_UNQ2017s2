﻿using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 500;

	public static int Lives;
	public int startLives = 20;

	public static int Waves;

	void Start(){
		Money = startMoney;
		Lives = startLives;

		Waves = 0;
	}
}
