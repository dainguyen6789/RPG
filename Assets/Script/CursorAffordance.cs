﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraUI;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour {

	[SerializeField] Texture2D walkCursor = null;
	[SerializeField] Texture2D targetCursor = null;
	[SerializeField] Texture2D unknownCursor = null;
	[SerializeField] Vector2 cursorHotspot = new Vector2(0f, 0f);
	CameraRaycaster cameraRaycaster;

	//[SerializeField] Texture2D buttonCursor = null;

	[SerializeField] const int walkableLayerNumber=8;

	[SerializeField] const int enemyLayerNumber=9;



	// Use this for initialization
	void Start () {
		cameraRaycaster = GetComponent<CameraRaycaster>();
		cameraRaycaster.notifyLayerChangeObservers += OnLayerChanged; // registering
	}

	void OnLayerChanged(int newLayer) {
		print ("Cursor over new layer");
		switch (newLayer)
		{
//		case 5: // TODO make cameraRaycaster member variables
//			Cursor.SetCursor (buttonCursor, cursorHotspot, CursorMode.Auto);
//			break;
		case walkableLayerNumber:
			Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
			break;
		case enemyLayerNumber:
			Cursor.SetCursor(targetCursor, cursorHotspot, CursorMode.Auto);
			break;
		default:
			Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
			return;
		}
	}

	// TODO consider de-registering OnLayerChanged on leaving all game scenes
}
