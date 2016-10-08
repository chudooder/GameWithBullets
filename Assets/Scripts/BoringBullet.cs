using UnityEngine;
using System.Collections;

public class BoringBullet : Bullet {

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
		} else if (other.CompareTag ("Player")) {
			if (other.GetComponent<Player>().Equals(source)) {
				Debug.Log ("self hit");
				return;
			}
		}
	}
}
