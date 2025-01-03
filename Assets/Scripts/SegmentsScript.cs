using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsScript : MonoBehaviour
{
    // Lo mismo que el BordersScript pero para la cola lmao

    public Devoul devoul;
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			devoul.GameOver();
		}

	}
}
