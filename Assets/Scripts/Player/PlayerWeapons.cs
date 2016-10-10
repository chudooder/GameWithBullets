using UnityEngine;
using System.Collections;

public class PlayerWeapons : MonoBehaviour {
	// Prefabs
	public Weapon[] initialWeapons = new Weapon[3];

	private Weapon[] weapons = new Weapon[3];

	void Start() {
		for (int i = 0; i < 3; i++) {
			Equip (i, initialWeapons [i]);
		}
	}

	void Update () {
		uint pid = GetComponent<Player>().playerId;

		if (Input.GetAxis (pid + "_Fire1") > 0) {
			weapons [0].Fire ();
		}

		if (Input.GetButton (pid + "_Fire2")) {
			weapons [1].Fire ();
		}

		// dash
		if (Input.GetButtonDown (pid + "_Dash")) {
			weapons [2].Fire ();
		}
	}

	public void Equip(int slot, Weapon prefab){
		weapons [slot] = Instantiate (prefab);
		weapons [slot].transform.SetParent (transform, false);
	}

	public Weapon GetWeapon(int slot) {
		return weapons [slot];
	}
}
