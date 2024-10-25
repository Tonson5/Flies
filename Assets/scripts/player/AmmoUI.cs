using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public GameObject uIHolder;
    // Start is called before the first frame update
    void Start()
    {
        //uIHolder = GameObject.Find("Ammo UI holder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = uIHolder.transform.position;
    }
}
