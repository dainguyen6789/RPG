using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;


public class Enemy : MonoBehaviour {
	
	float maxHealthPoints=100f;
	public float currentHealthPoints=100f;
	GameObject player = null;
	AICharacterControl aiCharacterControl=null;


	[SerializeField] float AttackDistance=10.0f;
	[SerializeField] float chaseRadius=10.0f;
	[SerializeField] float damagePerShot=10.0f;
	[SerializeField] GameObject projectileToUse;
	[SerializeField] GameObject projectileSocket;


	public float healthAsPercentage
	{
		get{ 
			return currentHealthPoints / maxHealthPoints;
		}
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		aiCharacterControl = GetComponent<AICharacterControl> ();
	}

	void Update()
	{
		float distance = Vector3.Distance (player.transform.position,transform.position);
		if (distance < AttackDistance) {
			aiCharacterControl.SetTarget(player.transform);
			SpawnProjectile ();
		} else {
			aiCharacterControl.SetTarget(transform);
		}
	}



	void SpawnProjectile()
	{
		GameObject newProjectile = Instantiate (projectileToUse, projectileSocket.transform.position, Quaternion.identity);
		Projectile projectileComponent = newProjectile.GetComponent<Projectile> ();
		projectileComponent.damageCause = damagePerShot;

		newProjectile.GetComponent<Projectile> ().damageCause = damagePerShot;
		Vector3 unitvectorToPlayer = (player.transform.position - projectileSocket.transform.position).normalized;
		float projectileSpeed = 50;//projectileComponent.projectileSpeed;
		newProjectile.GetComponent<Rigidbody> ().velocity = unitvectorToPlayer * projectileSpeed;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere (transform.position, AttackDistance);
		Gizmos.color = new Color (0, 0, 255, .5f);
	}

}
