using UnityEngine;

public class TriggerShopOpen : MonoBehaviour
{
        public OpenShop shopScript;
        
        public GameObject shopUI;
       
       
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
        {
                if (shopScript.isopen == false)
                {
                    shopScript.Openshop();
                }
               
            }
        }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (shopScript.isopen == true)
            {
                shopScript.Closeshop();
            }
        }

    }    
}
