using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	const float speed = 30;
	public Vector3 aimDirection;
	public Gun primaryGun;
	public Gun secondaryGun;
	public int playerId;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		primaryGun.Cooldown (Time.deltaTime);
		secondaryGun.Cooldown (Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		// movement
		Vector3 moveDirection = new Vector3 (Input.GetAxis (playerId + "_MoveH"), 0, Input.GetAxis (playerId + "_MoveV"));
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);

		// turning
		aimDirection = new Vector3 (Input.GetAxis (playerId + "_AimH"), 0, Input.GetAxis (playerId + "_AimV"));
		if (aimDirection.magnitude != 0.0) {
			transform.rotation = Quaternion.LookRotation (aimDirection);
		}

		// firing
		if (Input.GetButton (playerId + "_Fire1")) {
			primaryGun.Fire (transform.position, transform.forward);
		}

		if (Input.GetButton (playerId + "_Fire2")) {
			secondaryGun.Fire (transform.position, transform.forward);
		}
	}
}
