using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveForce = 20;
    float jumpForce = 10;

    Animator anim;
    SpriteRenderer spr;
    public GameObject platform;

    [SerializeField] private float movementSpeed = 3.0f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
          var xMovement = movement.x * movementSpeed * Time.deltaTime;
          this.transform.Translate(new Vector3(xMovement, 0));
        }
        rb.AddForce(transform.right*moveForce*Input.GetAxis("Horizontal"),ForceMode2D.Force);
        if(rb.velocity.magnitude>0.01f)
        {
          anim.SetBool("walking",true);
        }
        else{
          anim.SetBool("walking",false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up*jumpForce,ForceMode2D.Impulse);
        }
        if(rb.velocity.x>0)         // flips Kle to face direction she is walking
        {
            //spr.flipX = true;
            transform.localScale = Vector3.one;
        }
        else if(rb.velocity.x<0)
        {
            //spr.flipX = false;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col) // creates new platforms
    {
      if(col.tag=="Spawn")
      {
        float distance = Random.Range(8,10);
        float height = Random.Range(-3, 3);
        //Vector3 pos=transform.position;                 Original Idea for code
        //pos.x += distance;
        //Instantiate(platform, pos, Quaternion.identity);
        Instantiate(platform, new Vector3(transform.position.x+distance, height, 0), Quaternion.identity);

      }
    }

}
