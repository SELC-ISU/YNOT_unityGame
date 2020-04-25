using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private bool atDoor;
    // Start is called before the first frame update
    void Start()
    {
        atDoor = false;
    }

    //void Update(Collider2D Other) { 
        
    //}
    
    void OnTriggerEnter2D(Collider2D Other)
    {
        
        if (Other.tag == "Player")
        {
            atDoor = true;
           
        }
    }

    void OnTriggerStay2D(Collider2D Other)
    {
        if (atDoor && Input.GetKey(KeyCode.E))
        {

            Other.transform.position = transform.GetChild(0).position;
            atDoor = false;
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        atDoor = false;
    }
}
