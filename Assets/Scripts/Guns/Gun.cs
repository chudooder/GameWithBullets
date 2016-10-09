using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour, Cooldownable {

	public abstract float maxCooldown { get; }
	private float cooldown;

	public virtual void FixedUpdate () {
		cooldown = Mathf.Max(cooldown - Time.deltaTime, 0f);
	}

	public abstract string GetName ();

	public float GetCooldown () {
		return cooldown / maxCooldown;
	}

	protected void StartCooldown () {
		cooldown = maxCooldown;
	}

	protected abstract void Fire (Vector3 position, Vector3 direction);

	public void TryFire (Vector3 position, Vector3 direction) {
		if (cooldown == 0) {
			Fire (position, direction);
		}
	}
}
