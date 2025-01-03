using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradesSpawn : MonoBehaviour
{
    // Este Script se encarga de generar tardigrados aleatoriamente por el mapa
	
	public BoxCollider2D gridArea;
	
	public GameObject tardigradesWhoSpawns;
	
	public float spawnTime = 0f;
	
	
	private float RoundToMultipleOf10(float value)
	{
		return Mathf.Round(value / 10) * 10;
	}
	
	private void RandomizePosition()
	{
		Bounds bounds = this.gridArea.bounds;
		
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);
		
		x = RoundToMultipleOf10(x) + 5;
		y = RoundToMultipleOf10(y) + 5;

		tardigradesWhoSpawns.transform.position = new Vector3(x, y, 0.0f);
		Debug.Log("Se spawneo un tardígrado");
	}
	
	private void Update()
	{
		if(Time.time > spawnTime + 5.0f)
		{
			Debug.Log("Se intento spawnear un tardígrado");
			RandomizePosition();
			spawnTime = Time.time;
		}
		
	}
}
