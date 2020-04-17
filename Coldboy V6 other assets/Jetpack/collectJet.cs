using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectJet : MonoBehaviour
{
    public Inventory player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            player.jetCollect();
            Destroy(this.gameObject);
        }
    }
}
