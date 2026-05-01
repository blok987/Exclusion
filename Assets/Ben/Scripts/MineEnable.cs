using UnityEngine;

public class MineEnable : MonoBehaviour
{
    private Animator mineAnim;

    void Start()
    {
        mineAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mineAnim.SetBool("isBoom", true);
            
        }
    }

    public void MineDoneExploding()
    {
        Destroy(gameObject);
    }
}
