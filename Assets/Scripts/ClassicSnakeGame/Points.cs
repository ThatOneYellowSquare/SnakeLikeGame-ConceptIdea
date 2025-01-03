using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Muy importante esta línea para usar TextMeshPro

public class Points : MonoBehaviour
{
	public TextMeshProUGUI pointsText;
	public static int pointsScore = 0;
	public static bool gameOver = false;
	
	// ERROR que me daba:
	//No me dejaba asignar Text ya que en su lugar esta usando TextMeshProUGUI
	
	void Start()
	{
		pointsText = GetComponent<TextMeshProUGUI> ();
	}
	
	void Update()
	{
		if(gameOver == false)
			pointsText.text = "POINTS " + pointsScore;
		
		else
			pointsText.text = "SCORE: " + pointsScore;
		// El límite antes de que se desbore el texto es 99999
	}
}
