﻿using UnityEngine;
using System.Collections;

public class SpreadGun : BulletGun
{
	public override string UIName {
		get { return "Spread Shot"; }
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
			ShootBullet(localDirection: Quaternion.Euler(0, i * 15, 0));
		}
	}
}

