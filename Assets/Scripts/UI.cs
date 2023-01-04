using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI : MonoBehaviour
{   
    [SerializeField]
    GameObject[] objs;
    
    public GameObject script;
    private Canvas CanvasObject; // Assign in inspector
 
     void Start()
     {
         CanvasObject = GetComponent<Canvas> ();
         CanvasObject.enabled = false;
     }
 
     void Update() 
     {
         if (Input.GetKeyUp(KeyCode.Tab)) 
         {
             CanvasObject.enabled = !CanvasObject.enabled;
         }
     }

    public void Slot()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
    Debug.Log(name);
    }
  
}
