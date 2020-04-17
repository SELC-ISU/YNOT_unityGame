using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScript : MonoBehaviour
{
    public string itemName;
    public Inventory player;
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            player.addToInventory(itemName);
            Destroy(this.gameObject);
        }
    }
}
