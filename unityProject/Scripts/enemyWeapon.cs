using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemyWeapon : MonoBehaviour
{
    
    //where to create the ice bullet
    public Transform FirePointIce; 
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        ShootPlayer();
 
    }

    void ShootPlayer()
    {
        //create a bullet in firepointice location
        Instantiate(bullet, FirePointIce.position, FirePointIce.rotation); 
   
    }
}