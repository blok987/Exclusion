using UnityEngine;

public class MineEnable : MonoBehaviour
{
    private Animator mineAnim;

    private AudioSource mineAudio;

    private AudioClip mineExplosionSound;

    void Start()
    {
        mineAnim = GetComponent<Animator>();
        mineAudio = GetComponent<AudioSource>();
        mineExplosionSound = Resources.Load<AudioClip>("Audio/SFX/Explode");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mineAnim.SetBool("isBoom", true);
            mineAudio.PlayOneShot(mineExplosionSound);

        }
    }

    public void MineDoneExploding()
    {
        Destroy(gameObject);
    }
}
