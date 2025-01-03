using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tardigrade : MonoBehaviour
{
    // Variables
	public BoxCollider2D gridArea;
	public int foodPointsValue;
	
	public bool isDestroyedWhenEated; 
	
	
	void Start()
    {
        //RandomizePosition();
    }
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && isDestroyedWhenEated == false)
		{
			RandomizePosition();
			Points.pointsScore += foodPointsValue;
		}
		else if(other.tag == "Player" && isDestroyedWhenEated == true)
		{
			Destroy(gameObject);
			Debug.Log("Destruir objeto");
			Points.pointsScore += foodPointsValue;
		}
		
		if(other.tag == "Beetle" && isDestroyedWhenEated == false)
		{
			RandomizePosition();
		}
		if(other.tag == "Beetle" && isDestroyedWhenEated == true){
			Debug.Log("Destruir objeto");
			Destroy(gameObject);
		}
		
		/*else if(other.tag == "Obstacle")
		{
			RandomizePosition();
			Debug.Log("La fruta se intentó poner bajo la serpiente");
		}*/
	}
	
	private float RoundToMultipleOf10(float value){
		return Mathf.Round(value / 10) * 10;}
	
	private void RandomizePosition(){
		Bounds bounds = this.gridArea.bounds;
		
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);
		
		x = RoundToMultipleOf10(x) + 5;
		y = RoundToMultipleOf10(y) + 5;

		this.transform.position = new Vector3(x, y, 0.0f);}
}
