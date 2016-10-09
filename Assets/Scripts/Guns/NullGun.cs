using UnityEngine;
using System.Collections;

public class NullGun : Gun
{
	public override float maxCooldown {
		get { return 0; }
	}

	public override string GetName ()
	{
		return " -- ";
	}

	protected override void Fire(Vector3 position, Vector3 direction) {
		
	}
}

