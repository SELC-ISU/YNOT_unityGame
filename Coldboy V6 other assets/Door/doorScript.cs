using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public Animator door;
    public Inventory player;
    public string itemName;
    public BoxCollider2D doorCollision;
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (player.checkInvetoryFor(itemName))
            {
                door.SetBool("isOpen", true);
                doorCollision.enabled = false;
            }
        }
    }
}
