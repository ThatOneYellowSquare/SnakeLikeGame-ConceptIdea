using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    // Variables
	public int foodPointsValue;

	public Devoul devoul;

	// Esta variable se activara cuando vea comida para que vaya más rápido
	public bool angryBeetle = true;
	public Transform otherObject; // Referencia al otro objeto
	public Transform otherObjectB;
	float tolerance = 1f; // Margen de error permitido

	// Esta variable es para evitar un error
	//No es un método elegante pero me sirve
	float variableProvisionalAntierror = 0.0f;

	// Rferencia a los objetos de los colimllos
	public GameObject tusksObject;
	public Transform targetObject;

	// Y esta se activara cuando se choque de frente contra Devoul
	public bool ParryVar = false;
	
	// Variables de movimiento:
	private Vector2 directionVar = Vector2.right;
	private bool MigiHidori = false;

	public SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private float RoundToMultipleOf10(float value)
	{
		return Mathf.Round(value / 10) * 10;
	}
	
	private void RandomizePosition()
	{

		angryBeetle = false;
		int randomSpawnPosition = Random.Range(0, 2);

		if(randomSpawnPosition == 0)
			this.transform.position = new Vector3(115, 55, 0.0f);
		else if (randomSpawnPosition == 1){
			MigiHidori = true;
			this.transform.position = new Vector3(-115, -55, 0.0f);}
		else
			Debug.Log("Exception");
		}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		

		if(other.tag == "Player" && angryBeetle == true)
		{
			devoul.GameOver();
			Debug.Log("Te mato enfadado");
		}

		else if(other.tag == "Mouth" && angryBeetle == false)
		{
			RandomizePosition();
			Points.pointsScore += foodPointsValue;
			variableProvisionalAntierror = Time.time;
			Debug.Log("Te lo comiste de un mordisco");
		}

		else if(other.tag == "Player")
		{
			RandomizePosition();
			Points.pointsScore += foodPointsValue;
			variableProvisionalAntierror = Time.time;
			Debug.Log("Te lo comiste entero");
		}
		
		else if(other.tag == "SnakeSegment" && Time.time >= variableProvisionalAntierror + 1.0f)
		{
			devoul.GameOver();
			Debug.Log("Te mordio la cola");
		}

		else if(other.tag == "Obstacle")
		{
			if(MigiHidori == true)
				MigiHidori = false;
			else
				MigiHidori = true;
		}

		else if(other.tag == "Tardigrade")
		{
			//angryBeetle = !angryBeetle;
			angryBeetle = false;
		}
		
	}

	void Update()
    {
        if (Mathf.Abs(transform.position.x - otherObject.position.x) <= tolerance){
				//Debug.Log("¡Las posiciones X son aproximadamente iguales!");
				angryBeetle = true;
			}else if (Mathf.Abs(transform.position.y - otherObject.position.y) <= tolerance){
				//Debug.Log("¡Las posiciones Y son aproximadamente iguales!");
				angryBeetle = true;
			}

			else if (Mathf.Abs(transform.position.x - otherObjectB.position.x) <= tolerance){
				//Debug.Log("¡Las posiciones X son aproximadamente iguales!");
				angryBeetle = true;
			}else if (Mathf.Abs(transform.position.y - otherObjectB.position.y) <= tolerance){
				//Debug.Log("¡Las posiciones Y son aproximadamente iguales!");
				angryBeetle = true;
			}

		else
			angryBeetle = false;

		if(angryBeetle == true){
			spriteRenderer.color = Color.red;
		}else{
			spriteRenderer.color = Color.white;
		}
    }

	void FixedUpdate()
	{
		// Esto me lo dio ChatGPT, yo por si las moscas no toco
		Vector3 targetPosition = targetObject.position;

		if(ParryVar == true){
			if(MigiHidori == true){
			
			this.transform.position = new Vector3(
			(this.transform.position.x) + (directionVar.x * 0),
			(this.transform.position.y) + (directionVar.y * 0),
			0.0f);
			/*transform.position = new Vector3(targetPosition.x - 1.1f, targetPosition.y, targetPosition.z);
			Debug.Log("Interaccion 1");*/
			spriteRenderer.flipX = true;}
			else{
			this.transform.position = new Vector3(
			(this.transform.position.x) - (directionVar.x * 0),
			(this.transform.position.y) - (directionVar.y * 0),
			0.0f);
			spriteRenderer.flipX = false;}
		}

		else if(angryBeetle == true){
			if(MigiHidori == true){
			
			this.transform.position = new Vector3(
			(this.transform.position.x) + (directionVar.x * 10),
			(this.transform.position.y) + (directionVar.y * 10),
			0.0f);
			/*transform.position = new Vector3(targetPosition.x - 1.1f, targetPosition.y, targetPosition.z);
			Debug.Log("Interaccion 2");*/
			spriteRenderer.flipX = true;}
			else{
			this.transform.position = new Vector3(
			(this.transform.position.x) - (directionVar.x * 10),
			(this.transform.position.y) - (directionVar.y * 10),
			0.0f);
			spriteRenderer.flipX = false;}
		}
		
		else{
			if(MigiHidori == true){
			
			this.transform.position = new Vector3(
			(this.transform.position.x) + (directionVar.x * 5),
			(this.transform.position.y) + (directionVar.y * 5),
			0.0f);
			/*transform.position = new Vector3(targetPosition.x - 1.1f, targetPosition.y, targetPosition.z);
			Debug.Log("Interaccion 3");*/
			spriteRenderer.flipX = true;}
			else{
			this.transform.position = new Vector3(
			(this.transform.position.x) - (directionVar.x * 5),
			(this.transform.position.y) - (directionVar.y * 5),
			0.0f);
			spriteRenderer.flipX = false;}
		}
	}

	public void noSeNiComoLlamarEsteMetodo()
	{
		variableProvisionalAntierror = Time.time;
	}
}
