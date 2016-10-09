using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownIndicator : MonoBehaviour {

	public Player player;
	public int weapon;
	
	// Update is called once per frame
	void OnGUI () {
		if (player == null) {
			Destroy (gameObject);
			return;
		}
		GetComponent<Text> ().text = player.GetWeapon(weapon).GetName();
		float cooldown = player.GetWeapon (weapon).GetCooldown ();
		if (cooldown > 0) {
			GetComponent<Text> ().color = Color.Lerp (
				Color.white,
				new Color (0.2f, 0.2f, 0.2f, 1.0f),
				cooldown);
		} else {
			GetComponent<Text> ().color = new Color (0.4f, 1.0f, 0.4f, 1.0f);
		}
	}
}
