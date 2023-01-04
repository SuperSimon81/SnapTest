using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UI : MonoBehaviour
{   
    [SerializeField]
    GameObject[] prefabs;
    GameObject[] outline_prefabs;
    public TestCollider test_collider;
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
    //script.prefab = prefabs[name];
    //script.prefabOutline = outline_prefabs[name];
    Debug.Log(test_collider.prefab.name);
    
    }
  
}
