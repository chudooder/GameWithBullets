using UnityEngine;
using System.Collections;

public abstract class Hitbox : MonoBehaviour
{
	public Player src;

	void OnTriggerEnter(Collider collider){
		GameObject other = collider.gameObject;
		if (other.CompareTag ("Hurtbox")) {
			Player p = other.GetComponentInParent<Player> ();
			if (!p.Equals (src)) {
				HitPlayer (p);
			}
		} else if (other.CompareTag ("Wall")) {
			HitWall(other);
		}
	}

	protected abstract void HitPlayer (Player p);
	protected abstract void HitWall (GameObject wall);
}

