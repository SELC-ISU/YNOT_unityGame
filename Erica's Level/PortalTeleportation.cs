using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    private bool atPortal;

    // Start is called before the first frame update
    void Start()
    {
        atPortal = false;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnTriggerEnter2D(Collider2D Other)
    {

        if (Other.tag == "Player")
        {
            atPortal = true;

        }
    }
    void OnTriggerStay2D(Collider2D Other)
    {
        if (atPortal)
        {

            Other.transform.position = transform.GetChild(0).position;
            atPortal = false;
        }
    }

    void OnTriggerExit2D(Collider2D Other)
    {
        atPortal = false;
    }
}
