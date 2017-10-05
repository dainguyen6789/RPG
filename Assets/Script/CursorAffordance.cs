using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CameraUI
{
	[RequireComponent(typeof(CameraRaycaster))]
	public class CursorAffordance : MonoBehaviour {
		
			[SerializeField] Texture2D walkCursor = null;
			[SerializeField] Texture2D unknownCursor = null;
			[SerializeField] Texture2D targetCursor = null;
			[SerializeField] Vector2 cursorHotspot = new Vector2 (96, 96);

			CameraRaycaster cameraRaycaster;

			// Use this for initialization
			void Start () {
				cameraRaycaster = GetComponent<CameraRaycaster> ();
				cameraRaycaster.layerChangeObservers += OnDelegateCall;
			}
			
			// Only call when layer change
		void OnDelegateCall (Layer  newlayer) {
			print ("Cursor over new layer");
				switch (newlayer) {
					case Layer.Walkable:
						Cursor.SetCursor (walkCursor, cursorHotspot, CursorMode.Auto);
						break;
					case Layer.Enemy:
						Cursor.SetCursor (targetCursor, cursorHotspot, CursorMode.Auto);
						break;
					case Layer.RaycastEndStop:
						Cursor.SetCursor (unknownCursor, cursorHotspot, CursorMode.Auto);
						break;
					default:
						Debug.Log ("Do not know which cursor to show");
						return;
			
			}

		}
	}
}