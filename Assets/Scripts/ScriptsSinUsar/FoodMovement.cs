using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
	// Variables:
	private Vector2 directionVar = Vector2.right;
	private bool MigiHidori = false;
	
	void FixedUpdate()
	{
		if(MigiHidori == true){
		this.transform.position = new Vector3(
		(this.transform.position.x) + (directionVar.x),
		(this.transform.position.y) + (directionVar.y),
		0.0f);}
		else{
		this.transform.position = new Vector3(
		(this.transform.position.x) - (directionVar.x),
		(this.transform.position.y) - (directionVar.y),
		0.0f);}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacle" || other.tag == "SnakeSegment")
		{
			if(MigiHidori == true)
				MigiHidori = false;
			else
				MigiHidori = true;
		}
	}
}
