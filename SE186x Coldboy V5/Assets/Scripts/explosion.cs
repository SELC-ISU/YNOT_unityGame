using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Animator bullet;
   

    // Update is called once per frame
    void Update()
    {
        if(bullet.GetCurrentAnimatorStateInfo(0).IsName("nothing")) //if 'explosion' animation is done playing
        {
            Destroy(this.gameObject);//delete this game object so the screen doesn't become cluttered with invisible explosions
        }

    }
}
