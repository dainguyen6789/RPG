using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using CameraUI;
using UnityEngine.AI;

namespace Player_ns
{
[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (AICharacterControl))]


public class PlayerMovement : MonoBehaviour
{
	[SerializeField]  float walkMoveStopRadius=0.2f;
	[SerializeField] float attackStopRadius=3.0f;
		[SerializeField] const int enemyLayerNumber=9;
		[SerializeField] const int walkableLayerNumber=8;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
	public Vector3 currentDestination;
	Vector3 clickPoint;
		GameObject walkTarget;   
		AICharacterControl aiCharacterControl;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
			aiCharacterControl = GetComponent<AICharacterControl> ();
			cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;

			walkTarget = new GameObject ("walkTarget");
    }

		void ProcessMouseClick(RaycastHit raycastHit, int layerHit){
			switch (layerHit) {
			case enemyLayerNumber:
				//navigate to the enemy
				GameObject enemy = raycastHit.collider.gameObject;
				aiCharacterControl.SetTarget (enemy.transform);
				break;
			case walkableLayerNumber:
				walkTarget.transform.position = raycastHit.point;
				aiCharacterControl.SetTarget (walkTarget.transform);

				break;
			default:
				//navigate to the enemy
				return;
			}
		}

    // Fixed update is called in sync with physics
//    private void FixedUpdate()
//    {
//		clickPoint = cameraRaycaster.layerHit;
//        if (Input.GetMouseButton(0))
//        {
//			currentDestination = transform.position;
//			
//            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
//			switch (cameraRaycaster.layerHit) {
//				case Layer.Walkable:
//					currentDestination = ShortDestination (clickPoint, walkMoveStopRadius);
//				//currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
//				break;
//			case Layer.Enemy:
//				currentDestination = ShortDestination (clickPoint, attackStopRadius);
//				print ("Not moving to enemy");
//				break;
//			}
//        }
//			WalkToDestination ();
//
//
//    }

		void WalkToDestination ()
		{
			var playerToCLickPoint = currentDestination - transform.position;
			if (playerToCLickPoint.magnitude >= walkMoveStopRadius) {
				m_Character.Move (playerToCLickPoint, false, false);
			}
			else {
				m_Character.Move (Vector3.zero, false, false);
			}
		}

		Vector3 ShortDestination(Vector3 destination, float shortening)
		{
			Vector3 reductionVector = (destination - transform.position).normalized * shortening;
			return destination - reductionVector;
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.black;
			Gizmos.DrawLine (clickPoint, transform.position);
			Gizmos.DrawSphere (clickPoint, 2f);

		}
}
}
