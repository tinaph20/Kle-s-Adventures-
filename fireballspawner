using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class fireballspawner : MonoBehaviour
{
    public bool repeating = true;
    [SerializeField]
    GameObject fb_prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        while(repeating)
        {
            Instantiate(fb_prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
