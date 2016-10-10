using UnityEngine;
using System.Collections;

public class NullWeapon : Weapon
{
	public override string UIName {
		get { return "--"; }
	}
	protected override float MaxStartup{
		get { return 0; }
	}
	protected override float MaxActive {
		get { return 0; }
	}
	protected override float MaxCooldown{ 
		get { return 0; }
	}
	protected override void Activate () { }
}

