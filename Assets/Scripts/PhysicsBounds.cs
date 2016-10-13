using UnityEngine;
using System.Collections;

public class PhysicsBounds : MonoBehaviour {

	void OnTriggerExit(Collider c){
		Destroy (c.gameObject);
	}
		
}
