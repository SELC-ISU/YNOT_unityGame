using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxDamage : MonoBehaviour
{
    public GameObject box = null;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 4;

        if (box == null)
        {
            box = GameObject.FindGameObjectWithTag("box");
        }
    }

    public void damage(int hits)
    {
        if (hp <= 0)
        {
            Destroy(box);
        }

        else
        {
            hp -= hits;
        }
        
    }
}
