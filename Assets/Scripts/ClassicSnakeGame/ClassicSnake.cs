using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassicSnake : MonoBehaviour
{
	// Variables
	public GameObject gameOverText;
	public GameObject pauseText;
	public GameObject pointsText;
	public GameObject finalScore;
	public GameObject timeText;
	
	bool canYouPause = true;
	bool pausedVar = false;
	
	// La siguiente variable se encarga de que tenga que pasar X seg antes de volver a girar
	private float turnedTime;
	public float turnedDown; // El tiempo que tiene que pasar antes de poder volver a girar
	
	private Vector2 directionVar = Vector2.right;	
	
	// Estas variables se encargan de que no pueda dar media vuelta en seco
	private bool goingToUp, goingToDown, goingToLeft, goingToRight = true;
	
	// Esta variable se encarga de que tengan que pasar al menos 0,2 segundos para girar
	//y que de esa manera no se choque contra si mismo
	//	private float snakeTime = 0f;
	
	private List<Transform> segmentsVar;
	public Transform segmentPrefab;
	
	public TextMeshProUGUI timeTextUGUI; // Arrastra el objeto de texto desde el Inspector
	bool gameOver = false;
	
    void Start()
    {
        segmentsVar = new List<Transform>();
		segmentsVar.Add(this.transform);
		
		//TextMeshProUGUI timeTextComponent = timeText.GetComponent<TextMeshProUGUI>();
		
		Grow();
		Grow();
    }

    private void Update() //Se ejecuta cada fotograma
    {
			if(Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left")){
			// Movimiento básico (flechas)
				if(Input.GetKeyDown("up") && goingToDown==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.up;
					turnedTime = Time.time;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("down") && goingToUp==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.down;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("right") && goingToLeft==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.right;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown("left") && goingToRight==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.left;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
			else{
			// Movimiento básico (wasd)
				if(Input.GetKeyDown(KeyCode.W) && goingToDown==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.up;
					turnedTime = Time.time;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.S) && goingToUp==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.down;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.D) && goingToLeft==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.right;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown(KeyCode.A) && goingToRight==false && Time.time > turnedTime + turnedDown){
					directionVar = Vector2.left;
					turnedTime = Time.time;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
			
			// Este operador se encarga únicamente de alínear correctamente el timer en el game over
		if (gameOver==true){
            // Obtener el RectTransform del objeto de texto
            RectTransform rectTransform = timeTextUGUI.GetComponent<RectTransform>();
            // Modificar ancho y alto
            rectTransform.sizeDelta = new Vector2(160, 50);
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
			Mathf.Round(this.transform.position.x) + (directionVar.x * 10),
			Mathf.Round(this.transform.position.y) + (directionVar.y * 10),
			0.0f);
		// La posición siempre tiene que ser Vector3, incluso en juegos 2D
		// Mathf.Round se encarga de redondear la position del personaje
		//para que este alineado con las "casillas" de la cuadrícula.
		//En este caso lo multiplique * 10 antes de redondearlo ya que el
		//personaje era muy grande y no lo redondeaba con la cuadrícula
		
	}
	
	private void Grow()
	{
		Transform segment = Instantiate(this.segmentPrefab);
		segment.position = segmentsVar[segmentsVar.Count-1].position;
		segmentsVar.Add(segment);
	}
	
	private void GameOver()
	{
		// FunFact:
		//Al crear un script llamado "Time" esto paso a ser una referencia a ese script
		//y por tanto al darme error, en su lugar lo llamé "TimeScript"
		Points.gameOver = true;
		gameOverText.SetActive(true);
		pointsText.SetActive(false);
		finalScore.SetActive(true);
		timeText.transform.position = new Vector3(0.0f, -40.0f, 0.0f);
		gameOver = true;
		//timeTextComponent.alignment = TextAlignmentOptions.Center;
		canYouPause = false;
		Time.timeScale = 0f;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Food")
			Grow();
		else if(other.tag == "Obstacle" || other.tag == "SnakeSegment")
			GameOver();
	}
	
	private void Pause()
	{
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
