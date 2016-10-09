using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public const float MOVE_SPEED = 15;
	public StunBar stunBarPrefab;
	public Vector3 aimDirection;
	public int playerId;
	private float stunDuration;

	private Gun primaryGun {
		get { return GetComponentsInChildren<Gun> () [0]; }
	}

	private Gun secondaryGun {
		get { return GetComponentsInChildren<Gun> () [1]; }
	}

	private Dash dash {
		get { return GetComponentInChildren<Dash> (); }
		set {
			Destroy (GetComponentInChildren<Dash> ().transform.gameObject);
			Instantiate (value, transform);
		}
	}

	public bool invincible {
		get { return dash.IsDashing(); }
	}

	public bool stunned {
		get { return stunDuration > 0; }
	}

	public Color color {
		get { return GetComponent<MeshRenderer> ().material.color; }
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		stunDuration = Mathf.Max (0, stunDuration - Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (stunDuration > 0)
			return;

		CharacterController controller = GetComponent<CharacterController> ();

		// dash
		if (dash.IsDashing ()) {
			dash.Move (this);
			return;
		}

		// movement
		Vector3 moveDirection = new Vector3 (Input.GetAxis (playerId + "_MoveH"), 0, Input.GetAxis (playerId + "_MoveV"));
		moveDirection *= MOVE_SPEED;
		controller.Move (moveDirection * Time.deltaTime);

		// turning
		aimDirection = new Vector3 (Input.GetAxis (playerId + "_AimH"), 0, Input.GetAxis (playerId + "_AimV"));
		if (aimDirection.magnitude != 0.0) {
			transform.rotation = Quaternion.LookRotation (aimDirection);
		}

		// firing
		if (Input.GetAxis (playerId + "_Fire1") > 0) {
			primaryGun.Fire (transform.position, transform.forward);
		}

		if (Input.GetButton (playerId + "_Fire2")) {
			secondaryGun.Fire (transform.position, transform.forward);
		}

		// dash
		if (Input.GetButtonDown (playerId + "_Dash") && moveDirection.magnitude != 0) {
			dash.Attack (moveDirection.normalized);
		}
	}

	public void Stun(float duration) {
		stunDuration = duration;
		StunBar stunBar = (StunBar) Instantiate (stunBarPrefab);
		Vector2 screenCoords = Camera.main.WorldToScreenPoint (transform.position);
		stunBar.transform.SetParent (GameObject.FindGameObjectsWithTag ("UICanvas")[0].transform, false);
		stunBar.transform.position = new Vector3 (screenCoords.x, screenCoords.y + 13, 0);
		stunBar.timer = duration;
	}

	public Cooldownable GetWeapon(int index) {
		switch (index) {
		case 1:
			return primaryGun;
		case 2:
			return secondaryGun;
		case 3:
			return dash;
		default:
			return null;
		}
	}


}
