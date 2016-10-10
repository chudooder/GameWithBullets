using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	private const float SPEED = 15;

	public bool MoveLocked;
	public bool AimLocked;

	void Update () {
		CharacterController control = GetComponent<CharacterController> ();

		// Translation
		if (!MoveLocked) {
			control.Move (MoveInput * SPEED * Time.deltaTime);
		}

		// Rotation
		if (!AimLocked && AimInput.magnitude != 0) {
			transform.rotation = Quaternion.LookRotation (AimInput);
		}

	}

	// Computed properties
	public Vector3 MoveInput{
		get { 
			uint pid = GetComponent<Player> ().playerId;
			return new Vector3 (
				Input.GetAxis (pid + "_MoveH"), 
				0, 
				Input.GetAxis (pid + "_MoveV"));
		}
	}

	public Vector3 AimInput{
		get { 
			uint pid = GetComponent<Player> ().playerId;
			return new Vector3 (
				Input.GetAxis (pid + "_AimH"), 
				0, 
				Input.GetAxis (pid + "_AimV"));
		}
	}
}
