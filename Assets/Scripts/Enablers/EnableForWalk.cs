using UnityEngine;

public class EnableForWalk : MonoBehaviour
{
    public Collider2D collisionCollider;
    public WalkScript walkScript;
   

    private void Start()
    {
        
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (walkScript.isWalking)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            collisionCollider.enabled = false;
            
            

        }
        else if (walkScript.isWalking == false )
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            collisionCollider.enabled = true;
            


        }

        
    }
     
}