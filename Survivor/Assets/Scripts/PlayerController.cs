using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GameObject shoot;
	public float projectileSpeed;
	public float fireRepeatRate = 0.02f;


	private float minX;
	private float maxX;
	private float padding = .5f;
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;
	}

	void fireprojectile(){
		GameObject beam =  Instantiate(shoot,transform.position,Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			//transform.position += new Vector3(speed * Time.deltaTime,0f,0f);
			transform.position += Vector3.right*speed * Time.deltaTime;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			//fireprojectile();
			InvokeRepeating("fireprojectile",0.000001f,fireRepeatRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
		
			CancelInvoke("fireprojectile");
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left*speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp(transform.position.x, minX,maxX);
		transform.position = new Vector3(newX,transform.position.y, transform.position.z); 
	}


}
