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
		Debug.Log(other.gameObject.name.Replace("(Clone)", " ") + correctObject.name);

		if (other.gameObject.layer == 6){
			string nameOther = other.gameObject.name.Replace("(Clone)", "");
		
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