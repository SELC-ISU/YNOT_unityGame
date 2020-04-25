using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    //
    public float speed = 15f;
    public Rigidbody2D rb;
    public GameObject explosion;
    public enemyMove enemy;
    public GameObject enemyObj = null;
    public GameObject boxObj = null;
    public boxDamage box;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        if (enemyObj == null)
        {
            enemyObj = GameObject.FindGameObjectWithTag("enemy");
        }

        if (boxObj == null)
        {
            boxObj = GameObject.FindGameObjectWithTag("box");
        }

        enemy = enemyObj.GetComponent<enemyMove> ();
        box = boxObj.GetComponent<boxDamage> ();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int boxHP = 3;

        if (other.tag == "collider")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (other.tag == "enemy")
        {
            enemy.DamageEnemy(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (other.tag == "box")
        {
            //box.damage(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(boxObj);

            //if (boxHP <= 0)
            //{
            //    Destroy(boxObj);
            //}

            //else
            //{
            //    boxHP -= 1;
            //}
        }
    }
}


