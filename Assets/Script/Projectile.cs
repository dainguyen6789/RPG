using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float damageCause{ get; set;}
	public  float projectileSpeed{ get; set;}

	// Use this for initialization
	void OnTriggerEnter(Collider collider) {
        print("Projectile hit" +collider.gameObject);
        Component damageableComponent = collider.gameObject.GetComponent(typeof(IDamageable));
		if (damageableComponent) {

			(damageableComponent as IDamageable).TakeDamage (damageCause);
		}


    }
}
