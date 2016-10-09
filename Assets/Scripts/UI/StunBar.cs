using UnityEngine;
using System.Collections;

public class StunBar : MonoBehaviour {

	public float timer;
	public Vector2 Position;

	public float initTime;

	void Start () {
		initTime = timer;
	}

	void FixedUpdate () {
		timer -= Time.deltaTime;
	}

	// Update is called once per frame
	void OnGUI () {
		
		if (timer < 0) {
			Destroy (gameObject);
		}
		GetComponent<RectTransform>().localScale = new Vector3(timer / initTime, 1, 1);
	}
}
