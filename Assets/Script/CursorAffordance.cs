using UnityEngine;
using System.Collections;

public class CursorAffordance : MonoBehaviour {
	
	public Texture2D walkCursor ;
	[SerializeField] Vector2 cursorHotspot = new Vector2 (96, 96);
	//public Texture2D tex;
	//public Vector2 offset;
	CameraRaycaster cameraRaycaster;
	// Use this for initialization
	void Start () {
		cameraRaycaster = GetComponent<CameraRaycaster> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//switch (cameraRaycaster.layerHit) {
		//case Layer.Walkable:
			Cursor.SetCursor (walkCursor, cursorHotspot, CursorMode.Auto);
		//}
		//case Layer.Enemy:
			//Cursor.SetCursor (enemyCursor, cursorHotspot, CursorMode.Auto);
		
	
	}
}
