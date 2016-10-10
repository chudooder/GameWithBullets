using UnityEngine;
using System.Collections;

public class BasicDash : Weapon
{
	private const float SPEED = 50;

	public DashHitbox hitboxPrefab;

	private DashHitbox activebox;

	public override string UIName {
		get { return "Basic Dash"; }
	}
	protected override float MaxStartup{
		get { return 0; }
	}
	protected override float MaxActive {
		get { return 0.2f; }
	}
	protected override float MaxCooldown {
		get { return 2.0f; }
	}

	protected override bool Fireable {
		get { return GetComponentInParent<PlayerMovement> ().MoveInput.magnitude != 0; }
	}

	protected override void Activate() {
		PlayerMovement player = GetComponentInParent<PlayerMovement> ();
		player.MoveLocked = true;
		player.AimLocked = true;
		player.GetComponent<PlayerStun> ().PushUnstunnable ();
		transform.parent.transform.rotation = 
			Quaternion.LookRotation (player.MoveInput);
		
		activebox = Instantiate (hitboxPrefab);
		activebox.transform.SetParent (player.transform, false);
		activebox.src = player.GetComponent<Player> ();
	}

	protected override void ActiveUpdate() {
		Transform player = transform.parent.transform;
		player.GetComponent<CharacterController>().Move(
			player.forward * 50 * Time.deltaTime);
	}

	protected override void Deactivate() {
		GetComponentInParent<PlayerMovement> ().MoveLocked = false;
		GetComponentInParent<PlayerMovement> ().AimLocked = false;
		GetComponentInParent<PlayerStun> ().PopUnstunnable ();
		Destroy (activebox.gameObject);
		activebox = null;
	}
}

