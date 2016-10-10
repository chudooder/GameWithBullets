using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StunUI : MonoBehaviour {
	public PlayerStun stun;

	// Update is called once per frame
	void OnGUI () {
		if (stun.stun > 0) {
			transform.position = Camera.main.WorldToScreenPoint (
				stun.transform.position + new Vector3 (0, 0, 1.5f));
			GetComponent<RectTransform> ().localScale = 
				new Vector3 (stun.stun / stun.totalStun, 1, 1);
			GetComponent<Image> ().enabled = true;
		} else {
			GetComponent<Image> ().enabled = false;
		}
	}
}
