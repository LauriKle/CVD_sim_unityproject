using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	public GameObject scoreboard;
	public GameObject wrongObject;
	public GameObject correctObject;

	private string wrongName;
	private string correctName;

    private void Start() {
		wrongName = wrongObject.name;
		correctName = correctObject.name; 
		Debug.Log(wrongName + " " + correctName);
	}
    void OnCollisionEnter(Collision other) {
		//Debug.Log(other.gameObject.name.Replace("(Clone)", "") + correctObject.name);

		if (other.gameObject.layer == 6){
			string nameOther = other.gameObject.name.Replace("(Clone)", "");
			
			if (wrongName == nameOther) {
				scoreboard.GetComponent<ScoreboardScript>().incrementMissed(1);
			}
			else if (correctName == nameOther) {
				scoreboard.GetComponent<ScoreboardScript>().incrementCorrect(1);
			}
			Destroy(other.transform.gameObject);
		}
	}
}
