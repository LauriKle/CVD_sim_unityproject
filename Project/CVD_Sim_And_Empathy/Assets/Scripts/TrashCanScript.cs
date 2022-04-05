using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	public GameObject scoreboard;
	public GameObject correctObject;

	private string wrongName;
	private string correctName;

    private void Start() {
		correctName = correctObject.name;
	}
    void OnCollisionEnter(Collision other) {

		if (other.gameObject.layer == 6){
			string[] split = other.gameObject.name.Replace("(Clone)", " ").Split(' ');
			string nameOther = split[0];
			string id = split[1];

			if (correctName == nameOther) {
				scoreboard.GetComponent<ScoreboardScript>().incrementCorrect(1);
			}
			else {
				scoreboard.GetComponent<ScoreboardScript>().incrementMissed(1);
			}
			Destroy(other.gameObject);
		}
	}
}