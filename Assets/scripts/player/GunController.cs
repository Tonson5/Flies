using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    public GameObject ammoUI;
    public int ammo;
    public TextMeshPro ammoCounter;
    public GameObject bullet;
    
    void Start()
    {
        ammoUI = GameObject.Find("AmmoCounter");
        ammoCounter = ammoUI.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = "" + ammo;
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            ammo -= 1;
        }
    }
    private void OnDestroy()
    {
        Destroy(ammoUI);
    }
}
