using UnityEngine;
using System.Collections;

public class SpreadGun : Gun {

	public const float COOLDOWN = 0.25f;

	public float cooldown;
	public BoringBullet bulletPrefab;

	void FixedUpdate () {
		cooldown = Mathf.Max(cooldown - Time.deltaTime, 0f);
	}

	public override float GetCooldown () {
		return cooldown / COOLDOWN;
	}

	public override string GetName ()
	{
		return "Split Shot";
	}

	public override void Fire(Vector3 position, Vector3 direction) {
		if (cooldown > 0)
			return;

		for (int i = -1; i <= 1; i++) {
			BoringBullet bullet = (BoringBullet)Instantiate (
				bulletPrefab, 
				position + direction * 2, 
				Quaternion.LookRotation(direction) * Quaternion.Euler(0, i * 15, 0));

			bullet.velocity = 20;
			bullet.GetComponent<MeshRenderer> ().materials = GetComponentInParent<MeshRenderer> ().materials;
			bullet.source = GetComponentInParent<Player>();
		}

		cooldown = COOLDOWN;
	}
}
