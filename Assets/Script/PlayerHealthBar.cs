using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

	RawImage healthBarRawImage = null;
	Player player = null;

	// Use this for initialization
	void Start()
	{
		player = GetComponentInParent<Player>(); // Different to way player's health bar finds player
		healthBarRawImage = GetComponent<RawImage>();
	}

	// Update is called once per frame
	void Update()
	{
		float xValue = -(player.healthAsPercentage / 2f) - 0.5f;
		healthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
	}
}
