using UnityEngine;
using UnityEngine.UI;

public class TurretUIScript : MonoBehaviour {

	private NodeScript target;
	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;
	public Text sellAmount;

	public void SetTarget (NodeScript node){
		target = node;

		transform.position = target.GetBuildPosition ();
		ui.SetActive (true);

		if (!target.isUpgraded) {
			upgradeCost.text = "$" + target.turretM.upgradeCost;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "Done";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.turretM.SellAmount ();
	}

	public void Hide(){
		ui.SetActive (false);
	}

	public void Upgrade(){
		target.UpgradeTurret ();
		BuildManager.instance.DeselectNode ();
	}

	public void Sell(){
		target.SellTurret ();
		BuildManager.instance.DeselectNode ();
	}
}
