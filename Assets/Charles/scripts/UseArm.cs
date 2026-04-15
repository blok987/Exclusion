using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class UseArm : MonoBehaviour
{
    private GameObject Player;
    private Canvas c;
    private GameObject arm1;
    private GameObject arm11;
    private GameObject arm2;
    private GameObject arm22;
    public Image carm1;
    public Image carm2;
    public void Start()
    {
        c = FindAnyObjectByType<Canvas>();
        Player = GameObject.FindWithTag("Player");
        arm1 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
        arm11 = Player.transform.Find("Doll Forearm FRONT").gameObject;
        arm2 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
        arm22 = Player.transform.Find("Doll Forearm BACK").gameObject;
        carm1 = c.transform.Find("L arm").GetComponent<Image>();
        carm2 = c.transform.Find("R arm").GetComponent<Image>();
    }
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
            arm1 = Player.transform.Find("Doll Upper Arm FRONT").gameObject;
            arm11 = Player.transform.Find("Doll Forearm FRONT").gameObject;
            arm2 = Player.transform.Find("Doll Upper Arm BACK").gameObject;
            arm22 = Player.transform.Find("Doll Forearm BACK").gameObject;
        }
        carm1 = c.transform.Find("L arm").GetComponent<Image>();
        carm2 = c.transform.Find("R arm").GetComponent<Image>();
    }
}
