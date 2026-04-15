using UnityEngine;

public class MonetarySys : MonoBehaviour

{
    [SerializeField] bool HasSpall;
    public int SpallValue;
    [SerializeField] int Spallet;
    GameObject Spall;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpallValue = 1;

    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }



}
