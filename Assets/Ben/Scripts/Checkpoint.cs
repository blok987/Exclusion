using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector2 CurrentPoint; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentPoint = transform.position;
            Debug.Log("Checkpoint reached: " + CurrentPoint);
        }
    }
}
