using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour {
	public abstract void Cooldown (float timeDelta);
	public abstract void Fire(Vector3 position, Vector3 direction);
}
