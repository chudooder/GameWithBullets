using UnityEngine;
using System.Collections;

public class LaserGun : Gun
{

	public override float maxCooldown {
		get { return 3.0f; }
	}

	public Laser laserPrefab;

	private bool fired;
	private float firingDelay;

	public override void FixedUpdate () {
		base.FixedUpdate ();
		if (!fired)
			return;
		
		firingDelay -= Time.deltaTime;

		if (firingDelay < 0) {
			fired = false;
			Laser laser = (Laser)Instantiate (laserPrefab);
			laser.transform.SetParent (transform, false);
			laser.duration = 0.5f;
			laser.stunDuration = 1.0f;
			laser.source = GetComponentInParent<Player> ();
		}
	}

	public override string GetName ()
	{
		return "Laser Beam";
	}

	protected override void Fire(Vector3 _, Vector3 direction) {
		fired = true;
		firingDelay = 0.3f;
		StartCooldown ();
	}
}

