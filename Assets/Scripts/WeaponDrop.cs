using UnityEngine;
using System.Collections;

public class WeaponDrop : MonoBehaviour {
	public Weapon weapon;

	void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("Hurtbox")) {
			PlayerWeapons pweapons = collider.GetComponentInParent<PlayerWeapons> ();
			pweapons.Equip (weapon);
			Destroy (gameObject);
		}
	}
}
