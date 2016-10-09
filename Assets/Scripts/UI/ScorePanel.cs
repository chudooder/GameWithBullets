using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePanel : MonoBehaviour {

	public const int MAX_WIDTH = 400;
	public const int HEIGHT = 60;

	public Player player;

	private Text text;
	private Image bar;

	// Use this for initialization
	void Start () {
		Color pcolor = player.color;
		text = GetComponentInChildren<Text> ();
		bar = GetComponentInChildren<Image> ();
		text.color = pcolor;
		bar.color = pcolor;
	}

	// Update is called once per frame
	void Update () {
		TagScorer scorer = ((TagScorer)GameManager.instance.scorer);
		float score = scorer.TimeLeft (player);
		text.text = string.Format("{0:00}", score);
		GetComponent<RectTransform> ().sizeDelta = new Vector2 (
			(score / TagScorer.MAX_TIME) * MAX_WIDTH,
			HEIGHT);
	}
}
