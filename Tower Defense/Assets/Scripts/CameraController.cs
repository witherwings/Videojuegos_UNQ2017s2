﻿using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	private bool doMovement = false;

	public float panSpeed = 30f;
	public float panBorder = 10f;
	public float scrollSpeed = 5f;
	public float minY = 10f;
	public float maxY = 60f;

	public Button staticCamera;
	public Button dynamicCamera;

	void Start(){
		staticCamera.interactable = false;
		dynamicCamera.interactable = true;
	}

	void Update () {
		if (GameManager.GameIsOver) {
			this.enabled = false;
			return;
		}
			
		if (!doMovement) {return;}

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorder) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorder) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorder) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorder) {
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
	}

	public void changeCamera(){
		doMovement = !doMovement;
		staticCamera.interactable = !staticCamera.interactable;
		dynamicCamera.interactable = !dynamicCamera.interactable;
	}
}
