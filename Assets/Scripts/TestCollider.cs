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
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
            {
                //Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "BoxCollider")
                {
                    if(!isInstantiated)
                    {
                    isInstantiated=true;
                    //hit.collider.enabled = false;
                    child = Instantiate(prefabOutline,hit.transform.parent.position+hit.transform.localPosition*2,hit.transform.rotation);
                   
                   //Debug.Log("hit " + isInstantiated);
                   }
                }
                else
                {
                     if(isInstantiated && child.transform==hit.transform)
                    {
                        
                        
                        //child.transform.Rotate(new Vector3(Input.mouseScrollDelta.y*child.transform.position.x,Input.mouseScrollDelta.y*child.transform.position.y,Input.mouseScrollDelta.y*child.transform.position.z));
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            Instantiate(prefab,hit.transform.position,hit.transform.rotation);
                            Destroy(child);
                      
                        
                  
                        }
                       
                    }
                    //if(isInstantiated && child.transform!=hit.transform)
                    //{
                    //    Destroy(child);
                    //    isInstantiated=false;
                    //}
                   
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
