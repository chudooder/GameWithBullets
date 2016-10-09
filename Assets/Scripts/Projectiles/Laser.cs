using UnityEngine;
using System.Collections;

public class Laser : Projectile
{
	public float duration;

	void FixedUpdate () {
		duration -= Time.deltaTime;
		if (duration < 0) {
			Destroy (gameObject);
		}
	}


	public override bool DestroyOnTag (string tag) {
		return false;
	}

	public override bool CanHit (Player p) {
		return !p.stunned;
	}
}

