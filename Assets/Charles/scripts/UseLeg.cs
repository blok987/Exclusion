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
    public GameObject stuffbackground;
    public GameObject playerlimbs;
    public GameObject gameobject;



    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        stuffbackground = c.transform.Find("Stuff Background").gameObject;
        playerlimbs = stuffbackground.transform.Find("Player Limbs").gameObject;
        gameobject = playerlimbs.transform.Find("GameObject").gameObject;
        Player = GameObject.FindWithTag("Player");
        leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
        leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
        leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
        leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
        cleg1 = gameobject.transform.Find("L leg").GetComponent<Image>();
        cleg2 = gameobject.transform.Find("R leg").GetComponent<Image>();

    }
    void Update()
    {
        if (Player == null)
        {
            c = FindAnyObjectByType<Canvas>();
            stuffbackground = c.transform.Find("Stuff Background").gameObject;
            playerlimbs = stuffbackground.transform.Find("Player Limbs").gameObject;
            gameobject = playerlimbs.transform.Find("GameObject").gameObject;
            Player = GameObject.FindWithTag("Player");
            leg1 = Player.transform.Find("Doll Leg FRONT").gameObject;
            leg11 = Player.transform.Find("Doll Thigh FRONT").gameObject;
            leg2 = Player.transform.Find("Doll Leg BACK").gameObject;
            leg22 = Player.transform.Find("Doll Thigh BACK").gameObject;
            cleg1 = gameobject.transform.Find("L leg").GetComponent<Image>();
            cleg2 = gameobject.transform.Find("R leg").GetComponent<Image>();
        }

    }
    public void UseL()
    {
        if (leg1.activeSelf == false)
        {
            leg1.SetActive(true);
            leg11.SetActive(true);
            cleg1.color = new Color(1, 1, 1, 1f);
        }
        else if (leg2.activeSelf == false)
        {
            leg2.SetActive(true);
            leg22.SetActive(true);
            cleg2.color = new Color(1, 1, 1, 1f);
        }
    }
}
