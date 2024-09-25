using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveForce = 20;
    float jumpForce = 10;

    SpriteRenderer spr;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right*moveForce*Input.GetAxis("Horizontal"),ForceMode2D.Force);
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.tag=="Spawn")
      {
        float distance = Random.Range(5,8);
        float height = Random.Range(-3, 3);
        //Vector3 pos=transform.position;
        //pos.x += distance;
        //Instantiate(platform, pos, Quaternion.identity);
        Instantiate(platform, new Vector3(transform.position.x+distance, height, 0), Quaternion.identity);
        //Destroy(col.gameObject);
      }
    }
}
