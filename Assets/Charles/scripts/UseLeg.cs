using UnityEngine;
using UnityEngine.UI;

public class UseLeg : MonoBehaviour
{
    private GameObject Player;
    private Canvas c;
    private GameObject leg1;
    private GameObject leg11;
    private GameObject leg2;
    private GameObject leg22;
    public Image cleg1;
    public Image cleg2;




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
            cleg1 = c.transform.Find("L leg").GetComponent<Image>();
            cleg2 = c.transform.Find("R leg").GetComponent<Image>();
        }
        if (leg1.activeSelf == false || leg11.activeSelf == false)
        {
            cleg1.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            cleg1.color = new Color(1, 1, 1, 1f);
        }
    }  
}
