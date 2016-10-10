using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour {

	public PlayerWeapons weapons;
	
	// Update is called once per frame
	void OnGUI () {
		if (weapons == null) {
			Destroy (gameObject);
			return;
		}

		Weapon weapon = weapons.GetWeapon (tag);

		GetComponent<Text> ().text = weapon.UIName;
		float cooldown = weapon.Cooldown;
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
