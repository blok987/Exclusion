using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject armcollision;
    public Collider2D ArmcollisionCollider;
    private WalkScript walkScript;

    private void Start()
    {
        gameObject.SetActive(false);
        armcollision = gameObject.transform.Find("ArmCollision&Health").gameObject;    
        walkScript = transform.parent.GetComponent<WalkScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (walkScript.isRunning == true)
        {
            gameObject.SetActive(true);
        }
        else if (walkScript.isRunning == false)
        {
            gameObject.SetActive(false);
        }
    }
}
