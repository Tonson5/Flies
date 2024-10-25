using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicator : MonoBehaviour
{
    public GameObject door;
    public Material red;
    public Material green;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!door.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            GetComponent<MeshRenderer>().material = green;
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;

        }
    }
}
