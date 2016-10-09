using UnityEngine;
using System.Collections;

public class DefaultDash : Dash
{
	public const float SPEED = 50;
	public const float DURATION = 0.2f;
	public const float COOLDOWN = 2;

	public DashHitbox hitboxPrefab;

	private float duration;
	private float cooldown;
	private Vector3 direction;

	void FixedUpdate () {
		duration = Mathf.Max (0, duration - Time.deltaTime);
		cooldown = Mathf.Max (0, cooldown - Time.deltaTime);;
	}

	public override void Attack (Vector3 direction) {
		if (cooldown == 0) {
			duration = DURATION;
			cooldown = COOLDOWN;
			this.direction = direction;

			DashHitbox hitbox = (DashHitbox) Instantiate (
				hitboxPrefab, 
				transform.parent.position + transform.parent.forward, 
				transform.parent.rotation, 
				transform.parent);
			hitbox.timer = DURATION;
		}
	}

	public override bool IsDashing () {
		return duration > 0;
	}

	public override float GetCooldown () {
		return cooldown / COOLDOWN;
	}

	public override string GetName ()
	{
		return "Dash";
	}

	public override void Move (Player player) {
		if (IsDashing()) {
			player.GetComponent<CharacterController>().Move (direction * Time.deltaTime * SPEED);
		}
	}
}

