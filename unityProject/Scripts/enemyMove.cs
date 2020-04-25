using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyMove : MonoBehaviour
{
    public GameObject playerObj = null;
    public GameObject enemy = null;
    public int hp;
    public bool shot;
    public bool facingRight;
    //public bool hurt;
    public Animator animator;

    //where to create the ice bullet
    public Transform FirePointIce;
    public GameObject bullet;

    public float restTime = 0.8F;
    public float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        hp = 4;

        facingRight = transform.position.x > 0;

        //animator.SetBool("hurt" , false);
        //hurt = false;

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        if (enemy == null)
        {
            enemy = GameObject.Find("Ice Goat");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerObj.transform.position.x;
        float enemyX = enemy.transform.position.x;

        float difference = Math.Abs(playerX - enemyX);

        //animator.SetBool("hurt" , false);
        //hurt = false;

        //enemy.LookAt(playerObj);

        if (difference <= 10.2)
        {
            if (hp <= 0)
            {
                //destroy enemy
                Destroy(enemy);

            }

            else if (hp != 0)
            {
                if (!facingRight && playerObj.transform.position.x < 26)
                {
                    facingRight = true;
                    transform.Rotate(0f, 180f, 0f);
                }

                if (facingRight && playerObj.transform.position.x > 26)
                {
                    facingRight = false;
                    transform.Rotate(0f, 180f, 0f);
                }

                if (Time.time > nextFire)
                {
                    //shoot player
                    ShootPlayer();
                    nextFire = Time.time + restTime;
                }
            }
        }
    }

    void ShootPlayer()
    {

        //turn enemy towards player
        //transform.right = transform.position - playerObj.transform.position;
        //transform.Rotate(Vector3.forward, transform.rotate, Space.Self);

        //create a bullet in firepointice location
        Instantiate(bullet, FirePointIce.position, FirePointIce.rotation);

    }

    public void DamageEnemy(int hits)
    {
        hp -= hits;

        //animator.SetBool("hurt" , true);
        //hurt = true;
    }

}
