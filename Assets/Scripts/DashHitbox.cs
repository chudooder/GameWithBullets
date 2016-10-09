using UnityEngine;
using System.Collections;

public class DashHitbox : MonoBehaviour {

	public const float STUN_DURATION = 1.5f;
	public float timer;

	void FixedUpdate () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider collision) {
		GameObject other = collision.gameObject;
		Debug.Log(other);
		if (other.CompareTag ("Hurtbox")) {
			Player p = other.GetComponentInParent<Player> ();
			Player src = GetComponentInParent<Player> ();
			if (!p.Equals(src)) {
				p.Stun (STUN_DURATION);
				GameManager.instance.scorer.PlayerSliced (src, p);
			}
		}
	}
}
