using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
	private string correctName;
	private string nameOther;
	private string idOther;

	public GameObject scoreboard;
	public GameObject correctObject;
	public GameObject dataLogger;


    private void Start() {
		correctName = correctObject.name;
	}
    void OnCollisionEnter(Collision other) {

		if (other.gameObject.layer == 6){
			string[] split = other.gameObject.name.Replace("(Clone)", " ").Split(' ');
			nameOther = split[0];
			idOther = split[1];

			if (correctName == nameOther)
			{
				scoreboard.GetComponent<ScoreboardScript>().incrementCorrect(1);
			}
			else
			{
				scoreboard.GetComponent<ScoreboardScript>().incrementMissed(1);
			}
			dataLogger.GetComponent<LogToFile>().DataLog(FormatData());
			Destroy(other.gameObject);
		}
	}

	private string FormatData()
	{
		return nameOther[7].ToString() + "," + correctName[7] + "," + idOther;
	}
}