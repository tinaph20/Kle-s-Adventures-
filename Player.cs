using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Assumption: all objects colliding/triggering gameobject are enemies
    EnemyManager em;
    [SerializeField]
    float maxHealth = 100;
    //[SerializeField]//Used when debugging
    float curHealth;
    [SerializeField]
    RectTransform healthbarFill;
    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        curHealth = maxHealth;
    }

    void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        if(curHealth <= 0)
        {
            curHealth = maxHealth;
        }
        else
        {
            if(--curHealth <= 0)
            {
                //Todo: what are some other appropriate actions we might take
                //upon player death?
                Debug.Log("Died");
            }
        }
        if(em && em.usePooling)
            em.pool.pool.Release(other);
        else
            Destroy(other);
        //note: if curHealth and maxHealth were integers, int division is used
        float healthRatio = curHealth/maxHealth;
        //Debug.Log(healthRatio);
        healthbarFill.localScale = new Vector3(healthRatio, 1f, 1f);
        //Should work, but doesn't. Always fun to work out!
        //healthbarFill.localScale.Set(healthRatio, 1f, 1f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if(collider.tag == "Enemy")
            HandleEnemy(collider.gameObject);

        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.collider.tag == "Enemy")
            HandleEnemy(collision.collider.gameObject);
        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }
}
