using UnityEngine;
using System.Collections;

public class SpreadGun : Gun {

	public float cooldown;
	public BoringBullet bulletPrefab;
	public int player;

	public override void Cooldown(float deltaTime) {
		cooldown = Mathf.Max(cooldown - deltaTime, 0f);
	}

	public override void Fire(Vector3 position, Vector3 direction) {
		if (cooldown > 0)
			return;
		
		BoringBullet bullet = (BoringBullet)Instantiate (
			bulletPrefab, 
			position + direction * 2, 
			Quaternion.LookRotation(direction));
		
		bullet.velocity = 20;

		bullet.GetComponent<MeshRenderer> ().materials = 
			transform.parent.gameObject.GetComponent<MeshRenderer>().materials;

		cooldown = 0.25f;
	}
}
