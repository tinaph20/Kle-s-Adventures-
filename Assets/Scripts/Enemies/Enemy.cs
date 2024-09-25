using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    [SerializeField]
    float MoveSpeed = 1f;
    void Start()
    {
        player = FindObjectOfType<Player>();
        Debug.Log("Enemy Created");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * MoveSpeed);
    }

    void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
    }
}
