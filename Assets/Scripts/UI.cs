using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

using UnityEngine.UI;
public class UI : MonoBehaviour
{   
    [SerializeField]
    GameObject[] prefabs;
    [SerializeField]
    GameObject[] outline_prefabs;
    public Texture2D test;
    public Sprite sprit;
    public TestCollider test_collider;
    private Canvas CanvasObject; // Assign in inspector
 
     void Start()
     {
         CanvasObject = GetComponent<Canvas> ();
         CanvasObject.enabled = false;
         //Component test = CanvasObject.transform.GetChild(0).GetChild(0);
        
        
     }
 
     void Update() 
     {
         if (Input.GetKeyUp(KeyCode.Tab)) 
         {
             CanvasObject.enabled = !CanvasObject.enabled;
            
            
            int count = 0;
            foreach(GameObject prefab in prefabs)
            {
                Texture2D tex = AssetPreview.GetAssetPreview(prefab);  
                Rect rec = new Rect(0, 0, tex. width, tex. height);
                sprit = Sprite. Create(tex,rec,new Vector2(0,0),1);

                Image m_Image = CanvasObject.transform.GetChild(0).GetChild(count).GetComponent<Image>();
                m_Image.sprite = sprit;
                count++;
            }
            
         }
        
       
     }

    public void Slot()
    {
    string name = EventSystem.current.currentSelectedGameObject.name;
    test_collider.prefab = prefabs[int.Parse(name)];
    test_collider.prefabOutline = outline_prefabs[int.Parse(name)];
    
    Debug.Log(test_collider.prefab.name);
    
    }
  
}
