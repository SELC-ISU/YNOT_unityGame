using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint; //a point near CB, where the end of his gun is.
    public GameObject bullet;
    public Inventory player;
    public Animator playerState;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //if mouse0 is clicked
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (player.getEnergy() >= 5 && playerState.GetInteger("activeState") == 1) //if player has enough energy to shoot and is holding the gun
        {
            player.UseEnergy(5); //use 5 energy
            Debug.Log("Energy: " + player.getEnergy());
            Instantiate(bullet, FirePoint.position, FirePoint.rotation); // create a bullet
        }
    }
}
