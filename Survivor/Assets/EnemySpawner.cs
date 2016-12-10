using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		GameObject tempEnemy = Instantiate(enemy,new Vector3(0f,0f,0f),Quaternion.identity) as GameObject;
		tempEnemy.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
