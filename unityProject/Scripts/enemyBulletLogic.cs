using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletLogic : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public GameObject explosion;
    public Inventory player;
    public GameObject bullet = null;
    public GameObject playerObj = null;
    //public GameObject playerObj;

    float velY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * speed) * -1;

        if (bullet == null)
        {
            bullet = GameObject.FindGameObjectWithTag("bullet");
        }

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        player = playerObj.GetComponent<Inventory>();

        //playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collider")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        if (other.tag == "Player")
        {
            player.Damage(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
