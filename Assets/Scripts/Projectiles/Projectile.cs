using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
	public Player source;
	public float stunDuration;

	public abstract bool DestroyOnTag (string tag);
	public abstract bool CanHit (Player p);

	void OnTriggerEnter (Collider collision) {
		GameObject other = collision.gameObject;

		if (other.CompareTag ("Hurtbox")) {
			Player p = other.GetComponentInParent<Player> ();
			if (!p.Equals(source) && CanHit(p)) {
				p.Stun (stunDuration);
				GameManager.instance.scorer.PlayerShot (source, p);
			}
		}

		if (DestroyOnTag (other.tag)) {
			Destroy (gameObject);
		}

	}
}

