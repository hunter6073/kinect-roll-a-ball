using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;//initialize position
	}

	void LateUpdate () {
		if (player.transform.position.y > 0) {
			transform.position = player.transform.position + offset;//set an unchanging distance between the camera and the playerobject
		}
	}
}
