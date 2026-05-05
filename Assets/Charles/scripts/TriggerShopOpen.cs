using UnityEngine;

public class TriggerShopOpen : MonoBehaviour
{
        public OpenShop shopScript;
        
        public GameObject shopUI;
       
        private void Awake()
        {
            shopScript = GameObject.Find("shop iu").GetComponent<OpenShop>();
            
            shopUI = GameObject.Find("shop iu");
           
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (shopScript.isopen == false)
                {
                    shopScript.Openshop();
                }
               
            }
        }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (shopScript.isopen == true)
            {
                shopScript.Closeshop();
            }
        }

    }    
}
