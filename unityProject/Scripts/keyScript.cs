using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class keyScript : MonoBehaviour
{
    private bool hasKey;
    private GameObject key = null;
    private GameObject player = null;

    void Start()
    {
        
        if (key == null)
        {
            key = GameObject.FindGameObjectWithTag("key");
        }
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        hasKey = false;
    }

    void Update()
    {

        float playerX = player.transform.position.x;
        float keyX = key.transform.position.x;

        float dif = Math.Abs(playerX - keyX);

        if (dif < 0.5 && Input.GetKeyDown(KeyCode.E))
        {
            pickUpKey();
        }

    }

    void pickUpKey()
    {
        Destroy(key);

        hasKey = true;
    }

    public bool getHasKey()
    {
        return hasKey;
    }
}
