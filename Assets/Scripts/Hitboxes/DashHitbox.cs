using UnityEngine;
using System.Collections;

public class DashHitbox : Hitbox {
	private const float STUN = 1.5f;

	protected override void HitPlayer (Player p){
		GameManager.instance.scorer.PlayerDashed (src, p);
		p.GetComponent<PlayerStun>().Stun(STUN, PlayerStun.StackMode.Max);
	}

	protected override void HitWall(GameObject wall) { }
}
