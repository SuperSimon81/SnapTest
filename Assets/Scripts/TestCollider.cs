using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public GameObject prefab; 
    public GameObject prefabOutline;
    public bool isInstantiated = false;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit old_hit;
        RaycastHit hit;
        
        if(Physics.Raycast(ray,out hit))
            {
                //Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "BoxCollider")
                {
                    if(child.Equals(null) )
                    {
                   
                    isInstantiated=true;
                    //hit.collider.enabled = false;
                    
                    child = Instantiate(prefabOutline,hit.transform.parent.position+hit.transform.localPosition*2,hit.transform.rotation);
                   
                   //Debug.Log("hit " + isInstantiated);
                   }
                }       


            }
            
           else
            {
             if(isInstantiated)
                  {
                       Destroy(child);
                    isInstantiated=false;
                   }
             }
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("dsa");
    }
}
