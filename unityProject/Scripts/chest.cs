using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class chest : MonoBehaviour
{
    private keyScript key;
    private GameObject chestObj = null;
    private GameObject keyObj = null;
    private GameObject playerObj = null;
    private bool hasKey;
    private bool play;
    public float restTime = 0.8F;
    public float nextUpdate = 0.0F;
    public Sprite ladder;
    private SpriteRenderer spriteR;

    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        if (chestObj == null)
        {
            chestObj = GameObject.FindGameObjectWithTag("chest");
        }

        if (keyObj == null)
        {
            keyObj = GameObject.FindGameObjectWithTag("key");
        }

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
            
        }

        key = keyObj.GetComponent<keyScript> ();

        anim = GetComponent<Animator>();

        hasKey = key.getHasKey();

        play = false;

        spriteR = chestObj.GetComponent<SpriteRenderer>();


        //animator = chestObj.GetComponent<animator>();

        //if (animator == null)
        //{
        //    animator = playerObj.GetComponent<animator>();
        //}

        //animator.SetInteger("open", 0);
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerObj.transform.position.x;
        float chestX = chestObj.transform.position.x;
        hasKey = key.getHasKey();

        float dif = Math.Abs(playerX - chestX);

        if (dif < 0.5 && hasKey == true && Input.GetKey(KeyCode.E))
        {
            //play = true;
            //playAnimator();
            //Destroy(chestObj);

            anim.SetInteger("open", 1);
            play = true;

            
        }

        //else if (play)
        //{
            //spriteR.sprite = ladder;
        //}

        else {
            if (Time.time > nextUpdate)
            {
                anim.SetInteger("open", 0);
                nextUpdate = Time.time + restTime;
            }
            
            //play = false;
            //playAnimator();
        }



    }

    void playAnimator()
    {
        //Animator anim;

        //anim = chestObj.GetComponent<Animator>();

        if (play)
        {
            anim.SetInteger("open", 1);
        }

        else
        {
            anim.SetInteger("open", 0);
        }
        
    }
}
