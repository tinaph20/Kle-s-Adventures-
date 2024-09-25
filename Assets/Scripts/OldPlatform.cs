using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlatform : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x-transform.position.x>10)
        {
            Destroy(this.gameObject);
        }
    }
}
