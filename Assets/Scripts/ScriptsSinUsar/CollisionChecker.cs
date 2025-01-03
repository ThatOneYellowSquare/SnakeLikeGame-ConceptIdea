using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    // Este Script se debería encargar de que la comida no se pueda generar bajo un segmento de serpiente
	
    public string targetTag = "SnakeSegment";  // Etiqueta a verificar
    public Vector2 boxSize = new Vector2(1f, 1f);  // Tamaño de la caja

    void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, boxSize, 0f/*, collisionLayer*/);
        
        if (hit != null && hit.CompareTag(targetTag))
        {
            Debug.Log("Colisión detectada con " + hit.name);
			//Food.RandomizePosition();
        }
    }

    // Dibuja la caja de colisión en la escena
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
		//a
    }
}