using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]  float walkMoveStopRadius=3.0f;
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
			
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
			switch (cameraRaycaster.layerHit) {
			case Layer.Walkable:
				currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
				break;
			case Layer.Enemy:
				print ("Not moving to enemy");
				break;
			}
        }
		var playerToCLickPoint = currentClickTarget-transform.position;

		if (playerToCLickPoint.magnitude >= walkMoveStopRadius) {
			m_Character.Move (playerToCLickPoint, false, false);
		} else 
		{
			m_Character.Move (Vector3.zero, false, false);
		}

    }
}

