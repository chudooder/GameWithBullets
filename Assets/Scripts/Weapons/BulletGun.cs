using UnityEngine;
using System.Collections;

public abstract class BulletGun : Weapon
{
	private const float DEFAULT_SPEED = 20f;
	private const float DEFAULT_STUN = 0.6f;


	public Bullet bulletPrefab;

	protected void ShootBullet(
		Vector3? localPosition = null, 
		Quaternion? localDirection = null, 
		float speed = DEFAULT_SPEED, 
		float stun = DEFAULT_STUN
	){
		Vector3 position = transform.TransformPoint (localPosition ?? Vector3.zero);
		Quaternion direction = transform.rotation * (localDirection ?? Quaternion.identity);

		Bullet b = (Bullet)Instantiate (bulletPrefab, position, direction);
		b.speed = speed;
		b.stun = stun;
		b.src = GetComponentInParent<Player> ();
	}
}

