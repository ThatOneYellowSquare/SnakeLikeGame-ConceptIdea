using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake1Bit : MonoBehaviour
{
	// Variables
	public GameObject gameOverText;
	public GameObject pointsText;
	public GameObject finalScore;
	public GameObject timeText;
	
	private Vector2 directionVar = Vector2.right;	
	
	private bool goingToUp, goingToDown, goingToLeft, goingToRight = true;
	
	private List<Transform> segmentsVar;
	public Transform segmentPrefab;
	
	public TextMeshProUGUI timeTextUGUI;
	bool gameOver = false;
	
    void Start()
    {
        segmentsVar = new List<Transform>();
		segmentsVar.Add(this.transform);
		
		//Grow();
		//Grow();
    }

    private void Update()
    {
			if(Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left")){
			// Movimiento básico (flechas)
				if(Input.GetKeyDown("up") && goingToDown==false){
					directionVar = Vector2.up;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("down") && goingToUp==false){
					directionVar = Vector2.down;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown("right") && goingToLeft==false){
					directionVar = Vector2.right;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown("left") && goingToRight==false){
					directionVar = Vector2.left;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
			else{
			// Movimiento básico (wasd)
				if(Input.GetKeyDown(KeyCode.W) && goingToDown==false){
					directionVar = Vector2.up;
					goingToUp = true;goingToDown = false;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.S) && goingToUp==false){
					directionVar = Vector2.down;
					goingToUp = false;goingToDown = true;goingToLeft = false;goingToRight = false;
				}else if(Input.GetKeyDown(KeyCode.D) && goingToLeft==false){
					directionVar = Vector2.right;
					goingToUp = false;goingToDown = false;goingToLeft = false;goingToRight = true;
				}else if(Input.GetKeyDown(KeyCode.A) && goingToRight==false){
					directionVar = Vector2.left;
					goingToUp = false;goingToDown = false;goingToLeft = true;goingToRight = false;}
			}
			
		if (gameOver==true){
            RectTransform rectTransform = timeTextUGUI.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(160, 50);
        }
    }
	
	private void FixedUpdate()
	{
		for(int i=segmentsVar.Count-1; i>0; i--)
		{
			segmentsVar[i].position = segmentsVar[i-1].position;
		}
		
		this.transform.position = new Vector3(
			Mathf.Round(this.transform.position.x) + (directionVar.x * 20),
			Mathf.Round(this.transform.position.y) + (directionVar.y * 20),
			0.0f);
		
	}
	
	private void Grow()
	{
		Transform segment = Instantiate(this.segmentPrefab);
		segment.position = segmentsVar[segmentsVar.Count-1].position;
		segmentsVar.Add(segment);
	}
	
	private void GameOver()
	{
		Points.gameOver = true;
		gameOverText.SetActive(true);
		pointsText.SetActive(false);
		finalScore.SetActive(true);
		timeText.transform.position = new Vector3(0.0f, -40.0f, 0.0f);
		gameOver = true;
		Time.timeScale = 0f;
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Food")
			Grow();
		else if(other.tag == "Obstacle")
			GameOver();
	}
}
