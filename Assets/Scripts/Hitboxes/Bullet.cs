using UnityEngine;
using System.Collections;

public class Bullet : Hitbox {
	public float speed;
	public float stun;

	void Start(){
		GetComponent<MeshRenderer> ().materials = new Material[]{ src.baseMaterial };
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	protected override void HitPlayer(Player p){
		GameManager.instance.scorer.PlayerShot (src, p);
		p.GetComponent<PlayerStun>().Stun(stun);
		Destroy (gameObject);
	}

	protected override void HitWall(GameObject wall) {
		Destroy (gameObject);
	}
}
