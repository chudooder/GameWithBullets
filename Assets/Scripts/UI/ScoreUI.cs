using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public const int MAX_WIDTH = 400;
	public const int HEIGHT = 60;

	public Player player;

	private Text text;

	void Start () {
		Color pcolor = player.color;
		text = GetComponentInChildren<Text> ();
		Image bar = GetComponentInChildren<Image> ();
		text.color = pcolor;
		bar.color = pcolor;
	}

	void OnGUI () {
		TagScorer scorer = ((TagScorer)GameManager.instance.scorer);
		float score = scorer.TimeLeft (player);
		text.text = string.Format("{0:00}", score);
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (
			(score / scorer.maxTime) * MAX_WIDTH,
			HEIGHT);
	}
}
