using UnityEngine;
using System.Collections;

public class TrackingGun : Gun {

	public override float maxCooldown {
		get { return 0.15f; }
	}

	public Bullet bulletPrefab;

	public override string GetName ()
	{
		return "Tracking Shot";
	}

	protected override void Fire(Vector3 position, Vector3 _) {
		float bestDistance = 9999999f;
		Vector3 bestDirection = Vector3.zero;
		Player source = GetComponentInParent<Player> ();
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Player")) {
			Player p = go.GetComponent<Player>();
			if (p != source) {
				Vector3 dir = p.transform.position - source.transform.position;
				if (dir.magnitude < bestDistance) {
					bestDistance = dir.magnitude;
					bestDirection = dir.normalized;
				}
			}
		}

		Bullet bullet = (Bullet)Instantiate (
			bulletPrefab, 
			position + bestDirection * 2, 
			Quaternion.LookRotation(bestDirection));

		bullet.velocity = 15;
		bullet.stunDuration = 0.3f;
		bullet.GetComponent<MeshRenderer> ().materials = GetComponentInParent<MeshRenderer> ().materials;
		bullet.source = GetComponentInParent<Player>();

		StartCooldown ();
	}
}
