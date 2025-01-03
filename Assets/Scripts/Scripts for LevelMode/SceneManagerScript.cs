using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
	public string NombreDeEscena;
	public int tiempoDelAnteriorNivel;
	
    void Start()
    {
        
    }

    void Update()
    {
        if(Points.pointsScore == 500){
			SceneManager.LoadScene(NombreDeEscena);
			//tiempoDelAnteriorNivel = 
		}
		// Me daba error al haber llamado el script SceneManager
		//En su lugar lo llame SceneManagerScript
    }
	
}
