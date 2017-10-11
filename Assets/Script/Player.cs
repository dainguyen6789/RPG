﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour, IDamageable {
	float maxHealthPoints=100f;
	public float currentHealthPoints=100f;

	public float healthAsPercentage
	{
		get{ 
			return currentHealthPoints / maxHealthPoints;
		}
	}


    void IDamageable.TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
    }

}