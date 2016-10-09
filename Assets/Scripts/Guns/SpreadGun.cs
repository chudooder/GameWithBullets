using UnityEngine;
using System.Collections;

public class SpreadGun : Gun {

	public override float maxCooldown {
		get { return 0.3f; }
	}

	public Bullet bulletPrefab;

	public override string GetName ()
	{
		return "Split Shot";
	}

	protected override void Fire(Vector3 position, Vector3 direction) {
		for (int i = -1; i <= 1; i++) {
			Bullet bullet = (Bullet)Instantiate (
				bulletPrefab, 
				position + direction * 2, 
				Quaternion.LookRotation(direction) * Quaternion.Euler(0, i * 15, 0));

			bullet.velocity = 20;
			bullet.stunDuration = 0.6f;
			bullet.GetComponent<MeshRenderer> ().materials = GetComponentInParent<MeshRenderer> ().materials;
			bullet.source = GetComponentInParent<Player>();
		}

		StartCooldown ();
	}
}
