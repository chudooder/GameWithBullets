using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour {
	// Prefabs
	public NullWeapon nullWeapon;
	public Weapon[] initialWeapons;

	private Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

	void Start() {
		foreach (Weapon prefab in initialWeapons) {
			Equip (prefab);
		}
	}

	void Update () {
		uint pid = GetComponent<Player>().playerId;

		if (Input.GetAxis (pid + "_Fire1") > 0) {
			GetWeapon("MainWeapon").Fire ();
		}

		if (Input.GetButton (pid + "_Fire2")) {
			GetWeapon("SubWeapon").Fire ();
		}

		if (Input.GetButtonDown (pid + "_Dash")) {
			GetWeapon("DashWeapon").Fire ();
		}
	}

	public void Equip(Weapon prefab){
		weapons [prefab.tag] = Instantiate (prefab);
		weapons [prefab.tag].transform.SetParent (transform, false);
	}

	public Weapon GetWeapon(string tag) {
		if (weapons.ContainsKey (tag))
			return weapons [tag];
		else
			return nullWeapon;
	}
}
