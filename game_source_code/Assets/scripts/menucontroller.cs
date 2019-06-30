using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class menucontroller : MonoBehaviour {
	public Text txt;
	// Use this for initialization
	void Start () {
		string startpath = System.Environment.CurrentDirectory;
		string levelpath = startpath+@"\level.txt";
		StreamReader sr = new StreamReader (levelpath);
		string levelread = sr.ReadToEnd ();
		int level;
		level = int.Parse (levelread);
		if (level == 1) {
			txt.text = "start";
		}
		else {
			string text111="continue on level "+level.ToString();
			txt.text = text111;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startgame()
	{
		Application.LoadLevel (1);

	}
	public void quitgame()
	{
		Application.Quit();

	}
	public void enterlevel(int n)
	{
		Application.LoadLevel (1);

	}
}
