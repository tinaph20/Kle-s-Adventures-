using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
       position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        position.x = player.transform.position.x;
        transform.position =  position;
    }
}
