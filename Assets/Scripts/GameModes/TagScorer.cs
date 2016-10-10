using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TagScorer : Scorer {

	private Dictionary<Player, float> scores = new Dictionary<Player, float>();
	public Player runner;
	public Player[] players;
	public float maxTime;

	private bool gameOver;

	// Use this for initialization
	void Start () {
		foreach (Player p in players) {
			RegisterPlayer(p);
		}
			
		int pid = Random.Range (0, scores.Count);
		runner = players[pid];
	}

	// Update is called once per frame
	void Update () {
		if(gameOver)
			return;
		scores [runner] -= Time.deltaTime;
		if (scores [runner] < 0) {
			GameManager.instance.ReportVictory (runner);
			gameOver = true;
		}
	}

	public float TimeLeft (Player p) {
		return scores [p];
	}

	public override void RegisterPlayer (Player player) {
		scores [player] = maxTime;
	}

	public override void PlayerSliced (Player src, Player target) {
		if (target == runner) {
			runner = src;
		}
	}

	public override void PlayerShot (Player src, Player target) {

	}
}
