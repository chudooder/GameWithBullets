using UnityEngine;
using System.Collections;

public abstract class BulletGun : Weapon
{
	public Bullet bulletPrefab;

	protected void ShootBullet(Vector3 position, Vector3 velocity, float stun){
		Bullet b = (Bullet)Instantiate (
			bulletPrefab,
			position,
			Quaternion.LookRotation (velocity.normalized));

		b.speed = velocity.magnitude;
		b.stun = stun;
		b.src = GetComponentInParent<Player> ();
	}
}

