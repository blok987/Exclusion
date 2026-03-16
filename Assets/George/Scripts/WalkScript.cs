using UnityEngine;

public class WalkScript : MonoBehaviour
{
    [SerializeField] float WalkSpeed = 1.0f;
    public Vector2 PlayerDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        #region Player Movement Handling
        //Player Gravity
        PlayerDirection.y = GetComponent<Rigidbody2D>().linearVelocity.y;
        
        //Player Input Movement
        if (Input.GetKey(KeyCode.D)) 
        {
            PlayerDirection.x += WalkSpeed * Time.deltaTime;
        }
        GetComponent <Rigidbody2D>().linearVelocity = PlayerDirection;
        #endregion
    }
}
