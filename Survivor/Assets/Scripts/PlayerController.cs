using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;


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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)){
			//transform.position += new Vector3(speed * Time.deltaTime,0f,0f);
			transform.position += Vector3.right*speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left*speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp(transform.position.x, minX,maxX);
		transform.position = new Vector3(newX,transform.position.y, transform.position.z); 
	}


}
