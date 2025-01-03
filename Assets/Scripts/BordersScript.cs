using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersScript : MonoBehaviour
{
    public Devoul devoul;

    // Este script se encarga únicamente de que las paredes detecten cuando se choca la serpiente y SOLO la cabeza de la serpiente

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			devoul.GameOver();
		}

	}
}
