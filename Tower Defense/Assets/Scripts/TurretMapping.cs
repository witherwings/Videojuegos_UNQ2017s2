using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretMapping{

	public GameObject pfb;
	public int cost;

	public GameObject upgradedPfb;
	public int upgradeCost;

	public int SellAmount(){
		return cost / 2;
	}
}
