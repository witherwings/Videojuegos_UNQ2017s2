using UnityEngine;

public class PathScript : MonoBehaviour {

	public static Transform[] pathPoints;

	void Awake(){
		pathPoints = new Transform[transform.childCount];
		for (int i = 0; i < pathPoints.Length; i++) {
			pathPoints[i] = transform.GetChild (i);

		}
	}
}
