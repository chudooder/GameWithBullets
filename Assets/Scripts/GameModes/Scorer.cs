using UnityEngine;
using System.Collections;

public abstract class Scorer : MonoBehaviour {
	public abstract void RegisterPlayer (Player player);
	public abstract void PlayerSliced (Player src, Player target);
	public abstract void PlayerShot (Player src, Player target);
}
