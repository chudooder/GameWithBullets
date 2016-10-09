using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject winBannerPrefab;
	public Scorer scorer;
	public static GameManager instance;

	// Use this for initialization
	void Awake () {
		// singleton instantiation
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ReportVictory (Player p) {
		GameObject winBanner = Instantiate (winBannerPrefab);
		winBanner.transform.SetParent (GameObject.FindGameObjectsWithTag ("UICanvas")[1].transform, false);
		winBanner.GetComponentInChildren<Text> ().text = p.name + " WINS!";

		Camera.main.enabled = false;
		p.GetComponentInChildren<Camera> ().enabled = true;
	}
}
