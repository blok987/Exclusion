using System.Collections;
using UnityEngine;

public class CheeseChance : MonoBehaviour
{
    public GameObject cheese;
    
    public int cc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        cheese.SetActive(false);
        cc = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (cc == 39 || cc == 99)
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
