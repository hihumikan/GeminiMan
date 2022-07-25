using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
	private float time = 30;
	public Text text;

	void Start () {
	    text.text = "40s left";
	}
	
	void Update ()
	{
		time -= Time.deltaTime;

		if (time < 0) {
			SceneManager.LoadScene("GameOver");
		} else {
            text.text = ""+ System.Math.Floor(time)+"left!";
        }
	}

}
