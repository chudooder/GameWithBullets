using UnityEngine;
using System.Collections;

public abstract class Dash : MonoBehaviour, Cooldownable {
	public abstract float GetCooldown ();
	public abstract string GetName ();
	public abstract void Attack (Vector3 direction);
	public abstract bool IsDashing ();
	public abstract void Move (Player player);
}
