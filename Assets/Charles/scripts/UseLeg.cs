using UnityEngine;

public class UseLeg : MonoBehaviour
{
    private GameObject Player;
    private Canvas c;
    private GameObject leg1;
    private GameObject leg11;
    private GameObject leg2;
    private GameObject leg22;
    public GameObject cleg1;
    public GameObject cleg2;




    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
        leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
        leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
        leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
        
    }
    void Update()
    {
        if (Player == null)
        {
            c = FindAnyObjectByType<Canvas>();
            Player = GameObject.FindWithTag("Player");
            leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
            leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
            leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
            leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
        }
    }  
}
