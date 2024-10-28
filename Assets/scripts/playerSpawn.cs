using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        StartCoroutine(GrabPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GrabPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.Find("Player");
        player.transform.position = transform.position;
        Destroy(gameObject);
    }
}
