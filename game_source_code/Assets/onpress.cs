using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class onpress : MonoBehaviour{
	public player_controller pc;

	private void  Button_Click()
	{
		pc.accelerate ();
	}

}
