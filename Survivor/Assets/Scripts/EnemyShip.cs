using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float health = 150f;
	public GameObject enemyFire;
	public float projectileSpeed = -10f;
	public float shotsPerSec = .5f; 

	void Update(){
		float probability = shotsPerSec * Time.deltaTime;
		if(Random.value < probability){
			Fire ();
		}
	}

	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1f,0);
		GameObject messile = Instantiate(enemyFire,startPosition,Quaternion.identity) as GameObject;
		messile.rigidbody2D.velocity = new Vector2(0,-projectileSpeed);
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();

		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Destroy(gameObject);
			}
		}
	}
}
