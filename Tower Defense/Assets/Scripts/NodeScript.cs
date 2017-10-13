using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughColor;
	public Vector3 offset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretMapping turretM;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startingColor;

	BuildManager buildManager;

	void Start(){
		rend = GetComponent<Renderer> ();
		startingColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition(){
		return transform.position + offset;
	}

	void OnMouseDown(){
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;}

		if (turret != null) {
			buildManager.SelectNode(this);
			return;}

		if (! buildManager.CanBuild) {
			return;}

		BuildTurret (buildManager.GetTurretToBuild());
	}

	void OnMouseEnter(){
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;}
		if (! buildManager.CanBuild) {
			return;}
		if (buildManager.HasMoney) {
			rend.material.color = hoverColor; 
		} else {
			rend.material.color = notEnoughColor;
		}
	}

	void OnMouseExit(){
		rend.material.color = startingColor;
	}

	void BuildTurret(TurretMapping turretM){
		
		if (PlayerStats.Money < turretM.cost) {
			Debug.Log ("not enough money");
			return;
		}

		PlayerStats.Money -= turretM.cost;

		GameObject turretToBuild = (GameObject)Instantiate (turretM.pfb, GetBuildPosition (), Quaternion.identity);
		this.turret = turretToBuild;

		this.turretM = turretM;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);
	}

	public void UpgradeTurret(){

		if (PlayerStats.Money < turretM.upgradeCost) {
			Debug.Log ("not enough money");
			return;
		}

		PlayerStats.Money -= turretM.upgradeCost;

		Destroy (this.turret);

		GameObject turretToBuild = (GameObject)Instantiate (turretM.upgradedPfb, GetBuildPosition (), Quaternion.identity);
		turret = turretToBuild;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		isUpgraded = true;
	}

	public void SellTurret(){
		PlayerStats.Money += turretM.SellAmount ();

		GameObject effect = (GameObject)Instantiate (buildManager.sellEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		Destroy (turret);
		turretM = null;
	}
}
