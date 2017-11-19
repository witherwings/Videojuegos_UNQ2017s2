using UnityEngine;

public class ShopScript : MonoBehaviour {

	public TurretMapping standardTurret;
	public TurretMapping missileLauncher;
	public TurretMapping laserBeamer;
	public int livesCost;

	BuildManager buildManager;

	void Start(){
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret(){
		Debug.Log ("purchase");
		buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectMissileLauncher(){
		Debug.Log ("purchase");
		buildManager.SelectTurretToBuild (missileLauncher);
	}

	public void SelectLaserBeamer(){
		Debug.Log ("purchase");
		buildManager.SelectTurretToBuild (laserBeamer);
	}

	public void BuyLives(){
		Debug.Log ("purchase");
		PlayerStats.Lives ++;
		PlayerStats.Money -= livesCost;
	}
}
