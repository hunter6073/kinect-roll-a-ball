using UnityEngine;
using System.Collections;

public class gamecontroller : MonoBehaviour {
	public GameObject[] pickup;
	public GameObject[] trap;
	// Use this for initialization
	void Start () {
		int j,k;
		j = player_controller.levelcount;
		if (player_controller.levelcount>= 8) {
			k = j / 2;
		} 
		else {
			k=player_controller.levelcount / 2;
		}
		int i = 0;
		int setfalse;

		while(i!=j+1)
		{
			setfalse=Random.Range(0,61);
			if(pickup[setfalse].activeSelf==false)
			{
				pickup[setfalse].SetActive(true);
				i++;
			}
		}
		i = 1;
		while(i!=k+1)
		{
			setfalse=Random.Range(0,25);
			if(trap[setfalse].activeSelf==false)
			{
				trap[setfalse].SetActive(true);
				i++;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void restartgame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	public void quitgame()
	{
		Application.Quit();
	}
}
