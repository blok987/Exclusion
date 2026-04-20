using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class UseLeg : MonoBehaviour
{
    public GameObject Player;
    public GameObject legcolisionhealth;
    public Canvas c;
    public GameObject leg1;
    public GameObject leg11;
    public GameObject leg2;
    public GameObject leg22;
    
    public HealthLeg1 h2;
    public HealthLeg2 h;
    private int ran;


    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        legcolisionhealth = Player.transform.Find("LegCollision&Health").gameObject;
        
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
        leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
        leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
        leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
       
        h = legcolisionhealth.GetComponent<HealthLeg2>();
        h2 = legcolisionhealth.GetComponent<HealthLeg1>();

    }
    
    public void UseL()
    {
        if (leg11.activeSelf == false & leg22.activeSelf == false)
        {
            ran = Random.Range(1, 2);
        }    
        Debug.Log("UseL called");
        if (leg11.activeSelf == false & leg22.activeSelf == true || ran==2)
        {
            h.health = 10f;
            leg1.SetActive(true);
            leg11.SetActive(true);
           
            Debug.Log("leg1 activated");

        }
         if (leg22.activeSelf == false & leg11.activeSelf == true || ran==1)
        {
            h2.health = 10f;   
            leg2.SetActive(true);
            leg22.SetActive(true);
            
            Debug.Log("leg2 activated");

        }
         
    }
}
