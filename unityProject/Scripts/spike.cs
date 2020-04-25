using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    //SpriteRenderer anger;
    public Inventory player;
    //private BoxCollider2D thisSpike;
    // Start is called before the first frame update
    void Start()
    {
        //thisSpike = GetComponent < this.BoxCollider2D > ();
        //anger = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            player.Damage(1);
        }
    }
}
