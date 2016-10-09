using UnityEngine;
using System.Collections;

public class Bullet : Projectile {

	public float velocity;

	public override bool DestroyOnTag (string tag) {
		switch (tag) {
		case "Wall":
			return true;
		case "Hurtbox":
			return true;
		default:
			return false;
		}
	}

	public override bool CanHit (Player p) {
		return !p.invincible && !p.stunned;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
	}
}
