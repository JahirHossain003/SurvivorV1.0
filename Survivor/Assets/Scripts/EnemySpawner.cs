using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float height = 5f;
	public float width = 10f;

	public float speed = 2f;
	private float minX;
	private float maxX;
	// Use this for initialization
	void Start () {

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		minX = leftMost.x ;
		maxX = rightMost.x ;


		foreach(Transform child in transform){
			GameObject tempEnemy = Instantiate(enemy,child.transform.position,Quaternion.identity) as GameObject;
			tempEnemy.transform.parent = child.transform;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.right * speed * Time.deltaTime + transform.position; 

		if((transform.position.x + width/2 > maxX) || (transform.position.x < width/2 + minX  )){
			speed = speed * -1;
		}
	}
}
