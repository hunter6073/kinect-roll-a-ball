using UnityEngine;
using System.Collections;

public class rotater : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		//control the rotation of the pickupcubes
		transform.Rotate (new Vector3 (15, 30, 45)*Time.deltaTime);
	}
}
