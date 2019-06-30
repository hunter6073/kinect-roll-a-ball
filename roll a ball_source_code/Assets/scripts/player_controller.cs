using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
[System.Serializable]
public class player_controller : MonoBehaviour {
	private Rigidbody rb;
	public  float speed;
	public GameObject[] trap;
	public GameObject ground;
	public static int levelcount=1;
	public  float acceleratespeed;
	public float normalspeed;
	private Quaternion calibrationquaternion;
	public float smoothing;
	// Use this for initialization
	private int count;//integer to store the count of the pickups
	public Text counttext;//text used to count the pickups
	public Text wintext;//text used to display the message after winning
	void Awake()
	{

		string startpath = System.Environment.CurrentDirectory;
		string levelpath = startpath+@"\level.txt";
		StreamReader sr = new StreamReader (levelpath);
		string levelread = sr.ReadToEnd ();
		int level1;
		level1 = int.Parse (levelread);
		levelcount = level1;
		sr.Close ();
	}
	void Start () {
		//initializing the game
		rb = GetComponent<Rigidbody> ();//get the component that which the script is attached to;
		count = 0;
		setcounttext ();
		wintext.text = "";
		calibrateacelerometer ();
		normalspeed = speed;
	}
	
	// Update and FixedUpdate is called once per frame
	//Uptdate is called before rendering a frame, most of the game code is written here
	void Update () {
		
		for (int i=0; i<trap.Length; i++) {
			if(Mathf.Pow((trap[i].transform.position.x-transform.position.x),2)+Mathf.Pow((trap[i].transform.position.z-transform.position.z),2)<0.4&&trap[i].activeSelf==true)
			{
				MeshCollider mc;
				mc = ground.GetComponent<MeshCollider>();
				mc.enabled=false;
			}
		
		}

	}
	//FixedUpdate is called before performing any physics calculations
	void FixedUpdate(){
		               //  using keybord to get movement
		//using movehorizontal and movevertical to get the keyboard's input
		float movehorizontal = Input.GetAxis ("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);//create a vector3 to show the direction of the force
        if (Input.GetKey (KeyCode.Space)) {
			speed = acceleratespeed;
		} 
		else {

			speed=normalspeed;
		}
		//using phone input to get movement

		//Vector3 accelerationraw = Input.acceleration;
	    //Vector3 acceleration = fixacceleration (accelerationraw);
		//Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
		rb.AddForce (movement*speed*Time.deltaTime*smoothing);//give force to playerobject
			}
	void OnTriggerEnter(Collider other)//overriding a method to determine what happens after collision
	{
		if (other.gameObject.tag == "pickup") {//only disactive the pickups but not the walls or the ground
			other.gameObject.SetActive(false);
			count++;
			setcounttext();
		}

		

	}
	void setcounttext()// a method to set the text for counting pickups
	{

		counttext.text = "Level" + (levelcount).ToString ();
	

			if (count == levelcount+1) {
				levelcount++;
			    recordnextlevel();
				Application.LoadLevel (Application.loadedLevel);

			}

	}
	void calibrateacelerometer()
	{
		Vector3 accelerationsnapshot = Input.acceleration;
		Quaternion rotatequaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationsnapshot);
		calibrationquaternion = Quaternion.Inverse (rotatequaternion);
		
	}
	Vector3 fixacceleration(Vector3 acceleration)
	{
		Vector3 fixedacceleration = calibrationquaternion * acceleration;
		return fixedacceleration;
	}
	public void recordnextlevel()
	{
		string startpath = System.Environment.CurrentDirectory;
		string levelpath = startpath+@"\level.txt";
		StreamWriter sw = new StreamWriter (levelpath);
		sw.WriteLine (levelcount.ToString ());
		sw.Close ();
	}
	public void accelerate()
	{
		speed = acceleratespeed;
	}
	public void decelerate()
	{
		speed = normalspeed;

	}

}
