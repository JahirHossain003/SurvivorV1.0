using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {

		foreach(Transform child in transform){
			GameObject tempEnemy = Instantiate(enemy,child.transform.position,Quaternion.identity) as GameObject;
			tempEnemy.transform.parent = child.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
