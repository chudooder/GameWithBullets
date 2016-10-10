using UnityEngine;
using System.Collections;

public class SpreadGun : BulletGun
{
	private const float STUN = 0.6f;
	private const float SPEED = 20f;

	public override string UIName {
		get { return "Split Shot"; }
	}
	protected override float MaxStartup {
		get { return 0; }
	}
	protected override float MaxActive {
		get { return 0; }
	}
	protected override float MaxCooldown {
		get { return 0.3f; }
	}

	protected override void Activate (){
		for (int i = -1; i <= 1; i++) {
			this.ShootBullet (
				transform.position,
				Quaternion.Euler (0, i * 15, 0) * transform.forward * SPEED,
				STUN
			);
		}
	}
}

