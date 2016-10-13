using UnityEngine;
using System.Collections;

public class ArenaLight : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		Player runner = ((TagScorer)GameManager.instance.scorer).runner;
		Color pcolor = runner.color;
		GetComponent<Light> ().color = Color.Lerp (pcolor, Color.white, 0.2f);
	}
}
