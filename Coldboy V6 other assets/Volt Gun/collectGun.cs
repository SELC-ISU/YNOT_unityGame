using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectGun : MonoBehaviour
{
    public Inventory player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player"))
        {
            player.gunCollect();
            Destroy(this.gameObject);
        }
    }
}
