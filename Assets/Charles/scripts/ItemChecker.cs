using UnityEngine;
using UnityEngine.UI;

public class ItemChecker : MonoBehaviour
{
    public Image image;
    public GameObject ti;
    // Update is called once per frame
    void Start()
    {
        ti = this.gameObject;
    }
    void Update()
    {
        if (image.sprite == null)
        {
            ti.SetActive(false);
        }
         else
        {
            ti.SetActive(true);
        }
    }
}
