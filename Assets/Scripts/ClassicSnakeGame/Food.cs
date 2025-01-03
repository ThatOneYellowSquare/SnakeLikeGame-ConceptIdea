using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	// Variables
	public BoxCollider2D gridArea;
	private int pointsVar = 0;
	
	// Gracias ChatGPT 🙏
	private float RoundToMultipleOf10(float value)
	{
		return Mathf.Round(value / 10) * 10;
		// Se encarga de dividir el valor obtenido entre 10 y
		//luego multiplicarlo por 10 para redondear a multiplos de 10
	}
	
	private void RandomizePosition()
	{
		Bounds bounds = this.gridArea.bounds;
		
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);
		
		//this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
		
		// Redondeamos los valores que nos dan aleatoriamente a un múltiplo de 10
		x = RoundToMultipleOf10(x) + 5;
		y = RoundToMultipleOf10(y) + 5;
		// Y le sumamos 5 para alinearlo con las casillas

		this.transform.position = new Vector3(x, y, 0.0f);
		
		}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			RandomizePosition();
			Points.pointsScore += 100;
			pointsVar++;
			//Debug.Log("Puntaje: "+pointsVar);
		}
	}
	
	public int pointsVarMethod(int pointsVar)
	{
		this.pointsVar = pointsVar;
		return pointsVar;
	}
}
