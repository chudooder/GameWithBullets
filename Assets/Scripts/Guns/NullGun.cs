using UnityEngine;
using System.Collections;

public class NullGun : Gun
{
	
	public override float GetCooldown () {
		return 0;
	}

	public override string GetName ()
	{
		return "";
	}

	public override void Fire(Vector3 position, Vector3 direction) {
		
	}
}

