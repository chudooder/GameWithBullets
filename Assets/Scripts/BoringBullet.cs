using UnityEngine;
using System.Collections;

public class BoringBullet : MonoBehaviour {

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
		if (other.CompareTag ("wall")) {
			Destroy (gameObject);
		}
	}
}
