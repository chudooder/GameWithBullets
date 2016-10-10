using UnityEngine;
using System.Collections;

public class WeaponDrop : MonoBehaviour {
	public Weapon weapon;

	void OnTriggerEnter(Collider collider){
		if (collider.CompareTag ("Hurtbox")) {
			PlayerWeapons pweapons = collider.GetComponentInParent<PlayerWeapons> ();
			pweapons.Equip (weapon);
			GetComponentInParent<WeaponSpawn> ().PickedUp ();
			Debug.LogFormat ("{0} picked up a {1}", pweapons.name, weapon.UIName);
			Destroy (gameObject);
		}
	}
}
