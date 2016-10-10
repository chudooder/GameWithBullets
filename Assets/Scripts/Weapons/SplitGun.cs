using UnityEngine;
using System.Collections;

public class SplitGun : BulletGun
{
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
		get { return 0.2f; }
	}

	protected override void Activate (){
		for (int i = -1; i <= 1; i++) {
			this.ShootBullet (
				localPosition: new Vector3(i * 1.2f, 0, 0)
			);
		}
	}
}

