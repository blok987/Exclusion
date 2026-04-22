using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject armcollision;
    public Collider2D ArmcollisionCollider;
    private WalkScript walkScript;

    private void Start()
    {
        ArmcollisionCollider = armcollision.GetComponent<Collider2D>();
        walkScript = transform.parent.GetComponent<WalkScript>();
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (walkScript.isRunning == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            ArmcollisionCollider.enabled = false;
            

        }
        else if (walkScript.isRunning == false)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            ArmcollisionCollider.enabled = true;
            

        }
    }
}
