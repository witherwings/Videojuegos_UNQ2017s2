using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		if (instance != null) {
			Debug.LogError ("Too many BuildManagers");
			return;
		}	
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurretMapping turretToBuild;
	private NodeScript selectedNode;

	public TurretUIScript turretUI;

	public bool CanBuild { get { return turretToBuild != null; }}
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }}

	public void SelectNode(NodeScript node){

		if (selectedNode == node) {
			DeselectNode ();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		turretUI.SetTarget (node);
	}
		
	public void SelectTurretToBuild(TurretMapping turret){
		turretToBuild = turret;
		selectedNode = null;
		DeselectNode ();
	}

	public void DeselectNode(){
		selectedNode = null;
		turretUI.Hide();
	}

	public TurretMapping GetTurretToBuild(){
		return turretToBuild;
	}
}
