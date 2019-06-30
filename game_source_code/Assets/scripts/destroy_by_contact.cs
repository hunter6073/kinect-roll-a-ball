using UnityEngine;
using System.Collections;

public class destroy_by_contact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)//overriding a method to determine what happens after collision
	{
		if (other.gameObject.tag == "Player") {//only disactive the pickups but not the walls or the ground
			other.gameObject.SetActive(false);
		}
	}
}
