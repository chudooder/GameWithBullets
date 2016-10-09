using UnityEngine;
using System.Collections;

public class BoringBullet : Bullet {

	public const float STUN_DURATION = 0.6f;
	public float velocity;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
	}

	void OnTriggerEnter(Collider collision) {
		GameObject other = collision.gameObject;
		if (other.CompareTag ("Wall")) {
			Destroy (gameObject);
		} else if (other.CompareTag ("Hurtbox")) {
			Player p = other.GetComponentInParent<Player> ();
			if (!p.Equals(source) && !p.stunned && !p.invincible) {
				p.Stun (STUN_DURATION);
				// report to game manager
				GameManager.instance.scorer.PlayerShot (source, p);
			}
		}
	}
}
