using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public bool isenabled = false;
    public GameObject prefab; 
    public GameObject prefabOutline;
    public bool isInstantiated = false;
    public GameObject preview;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    RaycastHit old_hit = new RaycastHit();

    // Update is called once per frame
    void Update()
    {
        if (!isenabled)
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            //did we hit a boxcollider
            if (hit.transform.tag == "BoxCollider")
            {
                //is it the same one we already hit?
                if (hit.colliderInstanceID != old_hit.colliderInstanceID)
                {
                    //if there was a previous preview we destroy it,
                    if (!preview.Equals(null))
                    {
                        Destroy(preview);
                    }
                    //we make a new one.
                    preview = Instantiate(prefabOutline, hit.transform.parent.position + hit.transform.localPosition * 2, hit.transform.rotation);
                    old_hit = hit;
                    Debug.Log("remaking a preview");
                }
                else
                {
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {             
                        
                       Instantiate(prefab, preview.transform.position, preview.transform.rotation);
                       Destroy(preview);
                        old_hit = new RaycastHit();                        
                    }
                }
            }
            else
            {
                Destroy(preview);
                old_hit = new RaycastHit();
            }            
        }     
       
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("dsa");
    }
}
