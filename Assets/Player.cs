﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
	float maxHealthPoints=100f;
	public float currentHealthPoints=100f;

	public float healthAsPercentage
	{
		get{ 
			return currentHealthPoints / maxHealthPoints;
		}
	}

}