using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDfollow : MonoBehaviour
{
    public GameObject Coldboy;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Coldboy.transform.position.x, Coldboy.transform.position.y, -1f);
    }
}
