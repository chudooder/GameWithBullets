using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

	public void ReportVictory (Player p) {
		GameObject winBanner = Instantiate (winBannerPrefab);
		winBanner.transform.SetParent (GameObject.FindGameObjectsWithTag ("UICanvas")[1].transform, false);
		winBanner.GetComponentInChildren<Text> ().text = p.name + " WINS!";

		Camera.main.enabled = false;
		p.GetComponentInChildren<Camera> ().enabled = true;
		Invoke ("backToMenu", 5.0f);
	}

	private void backToMenu(){
		SceneManager.LoadScene ("start");
	}
}
