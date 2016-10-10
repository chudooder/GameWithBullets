using UnityEngine;
using System.Collections;

public class WeaponSpawn : MonoBehaviour
{
	public WeaponDrop dropPrefab;
	public Weapon[] weapons;

	public float frequency;
	public float deviation;

	void Start(){
		float next = RandomFromDistribution.RandomNormalDistribution (frequency / 2, deviation / 2);
		Invoke ("CreateDrop", next);
	}

	public void PickedUp(){
		float next = RandomFromDistribution.RandomNormalDistribution (frequency, deviation);
		Invoke ("CreateDrop", next);
	}

	private void CreateDrop(){
		WeaponDrop drop = Instantiate (dropPrefab);
		drop.transform.SetParent (transform, false);
		drop.weapon = weapons[Random.Range(0, weapons.Length - 1)];
	}
}

