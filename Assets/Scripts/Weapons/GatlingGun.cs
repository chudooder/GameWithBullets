using UnityEngine;
using System.Collections;

public class GatlingGun : BulletGun
{
	public const int MAX_BULLETS = 25;	public const float SPEED = 20f;
	private const float STUN = 0.6f;

	public override string UIName {
		get { return "Gatling Cannon"; }
	}
	protected override float MaxStartup {
		get { return 0.3f; }
	}
	protected override float MaxActive {
		get { return 1.2f; }
	}
	protected override float MaxCooldown {
		get { return 4f; }
	}

	private int bullets;

	protected override void Activate () {
		bullets = MAX_BULLETS;
	}

	protected override void ActiveUpdate() {
		if((float) bullets / MAX_BULLETS >= Active){
			float angle = RandomFromDistribution.RandomNormalDistribution (0, 3.5f);
			ShootBullet(localDirection: Quaternion.Euler (0, angle, 0));
			bullets--;
		}
	}
}



