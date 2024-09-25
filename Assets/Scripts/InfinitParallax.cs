using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitParallax : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxEffect; // speed background moves compared to camera

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate() // makes the parallex smoother
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam, 1 = no move
        float movement = cam.transform.position.x *(1-parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(movement > startPos + length)
        {
            startPos += length;
        }
        else if(movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
