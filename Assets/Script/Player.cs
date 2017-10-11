using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraUI;

public class Player : MonoBehaviour, IDamageable {
	float maxHealthPoints=100f;
	int enemyLayer=9;
	public float currentHealthPoints=100f;
	CameraRaycaster cameraRaycaster;
	public float healthAsPercentage
	{
		get{ 
			return currentHealthPoints / maxHealthPoints;
		}
	}


	void Start(){
		cameraRaycaster = FindObjectOfType<CameraRaycaster> ();
		cameraRaycaster.notifyMouseClickObservers += OnMouseClick;
	}

	void OnMouseClick(RaycastHit raycasthit, int layerHit){
		if (layerHit == enemyLayer) {
		
			var enemy = raycasthit.collider.gameObject;
			print ("Click Enemy" + enemy);
		}
	}

    void IDamageable.TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
    }

}