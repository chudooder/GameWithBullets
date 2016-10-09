using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour, Cooldownable {
	public abstract float GetCooldown ();
	public abstract string GetName ();
	public abstract void Fire (Vector3 position, Vector3 direction);
}
