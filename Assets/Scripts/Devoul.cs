using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Devoul : MonoBehaviour
{
	// Variables
	public GameObject gameOverText;
	public GameObject pauseText;
	public GameObject pointsText;
	public GameObject finalScore;
	public GameObject timeText;
	public GameObject playAgainButton;

	public Beetle beetle;

	public SpriteRenderer SpriteRenderer;
	
	private Vector2 directionVar = Vector2.right;	
	
	// Estas variables se encargan de que no pueda dar media vuelta en seco
	private bool goingToUp, goingToDown, goingToLeft, goingToRight = true;
	
	// La siguiente variable se encarga de que tenga que pasar X seg antes de volver a girar
	private float turnedTime;
	public float turnedDown; // El tiempo que tiene que pasar antes de poder volver a girar

	// Estas variables se encargan de que Devoul se pare al chocarse contra los colmillos de un Beetle
	private float velocityVar = 10;
	public bool dizziness;
	public float dizzinessTime;

	// Las variables que se usan para pausar
	bool canYouPause = true;
	bool pausedVar = false;
	
	private int nextLevel;
	
	private List<Transform> segmentsVar;
	public Transform segmentPrefab;
	
	public TextMeshProUGUI timeTextUGUI; // Arrastra el objeto de texto desde el Inspector
	bool gameOver = false;
	
    void Start()
    {
        segmentsVar = new List<Transform>();
		segmentsVar.Add(this.transform);
				
		Grow();
		Grow();
    }

    private void Update() //Se ejecuta cada fotograma
    {
		if(dizziness == false){
			if(Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left")){
			// Movimiento básico (flechas)
				if(Input.GetKeyDown("up") && goingToDown==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.up;
					UpRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("down") && goingToUp==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.down;
					DownRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("right") && goingToLeft==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.right;
					NormalRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown("left") && goingToRight==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.left;
					NormalRotation();
					SpriteRenderer.flipX = true;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
			else{// Movimiento básico (wasd)
				if(Input.GetKeyDown(KeyCode.W) && goingToDown==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.up;
					UpRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.S) && goingToUp==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.down;
					DownRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.D) && goingToLeft==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.right;
					NormalRotation();
					SpriteRenderer.flipX = false;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown(KeyCode.A) && goingToRight==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.left;
					NormalRotation();
					SpriteRenderer.flipX = true;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
		}
			
			// Este operador se encarga únicamente de alínear correctamente el timer en el game over
		if (gameOver==true){
            // Obtener el RectTransform del objeto de texto
            RectTransform rectTransform = timeTextUGUI.GetComponent<RectTransform>();
            // Modificar ancho y alto
            rectTransform.sizeDelta = new Vector2(160, 50);
        }

		// Este operador se encarga únicamente de contar el medio segundo que Devoul se marea al chocarse contra los colmillos
		if(dizziness == true && Time.time > dizzinessTime + 0.25)
		{
			dizziness = false;
			Debug.Log("Despierta, es hora de hornear unos momazos");
			velocityVar = 10;
		}

		if (Input.GetKeyDown("escape") && canYouPause == true)
			{
				Pause();
			}
    }
	
	private void FixedUpdate() //Se ejecuta de manera estable siempre
	{
		for(int i=segmentsVar.Count-1; i>0; i--)
		{
			segmentsVar[i].position = segmentsVar[i-1].position;
		}
		
		this.transform.position = new Vector3(
			Mathf.Round(this.transform.position.x) + (directionVar.x * velocityVar),
			Mathf.Round(this.transform.position.y) + (directionVar.y * velocityVar),
			0.0f);
		
	}
	
	private void Grow()
	{
		Transform segment = Instantiate(this.segmentPrefab);
		segment.position = segmentsVar[segmentsVar.Count-1].position;
		segmentsVar.Add(segment);
	}
	
	public void GameOver()
	{
		Points.gameOver = true;
		gameOverText.SetActive(true);
		pointsText.SetActive(false);
		finalScore.SetActive(true);
		timeText.transform.position = new Vector3(0.0f, -40.0f, 0.0f);
		gameOver = true;
		playAgainButton.SetActive(true);
		Time.timeScale = 0f;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Beetle"){
			beetle.noSeNiComoLlamarEsteMetodo();
			Grow();
		}
		else if(other.tag == "Tardigrade")
			nextLevel++;
			//Debug.Log(nextLevel);
			if(nextLevel >= 10){
				Grow();
				nextLevel = 0;}
		else if(other.tag == "Tusk"){
			Debug.Log("Mordido");
			velocityVar = 0;
			dizzinessTime = Time.time;
			dizziness = true;
			//Beetle.ParryVar = false;
		}
		///*else if(/*other.gameObject.CompareTag("Player") && */other.tag == "Obstacle" || other.tag == "SnakeSegment"/* && dizziness == false*/)
		//	GameOver();*/
		else if(other.tag == "SnakeSegment")
			GameOver();
	}

	// Rotar el personaje
	public void UpRotation() {
        transform.rotation = Quaternion.Euler(0, 0, 90); }
	public void DownRotation(){
        transform.rotation = Quaternion.Euler(0, 0, -90); }
	public void NormalRotation(){
        transform.rotation = Quaternion.Euler(0, 0, 0); }


	private void Pause(){
		if(pausedVar == false)
		{
			Time.timeScale = 0f;
			pauseText.SetActive(true);
			pausedVar = true;
		}
		else
		{
			Time.timeScale = 1f;
			pauseText.SetActive(false);
			pausedVar = false;
		}
	}
}
