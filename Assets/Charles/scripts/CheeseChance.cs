using System.Collections;
using UnityEngine;

public class CheeseChance : MonoBehaviour
{
    public GameObject cheese;
    public GameObject player;
    private Rigidbody playerRb;
    public int cc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        cheese.SetActive(false);
        cc = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (cc == 39)
        {
            StartCoroutine(Cheesee());
        }
        else
        {
            cheese.SetActive(false);
        }

    }
    public IEnumerator Cheesee()
    {
        cheese.SetActive(true);
        yield return new WaitForSeconds(5f);
        cheese.SetActive(false);
        cc = 38;
    }
   
}
