using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    public GameObject ammoUI;
    public GameObject bulletSpawn;
    public int ammo;
    public TextMeshPro ammoCounter;
    public GameObject bullet;
    public AudioClip shoot;
    public AudioClip earRing;
    public AudioSource gunShot;
    public AudioSource earRinging;
    public float earRingingVolume;
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
            gunShot.PlayOneShot(shoot);
            earRinging.PlayOneShot(earRing);
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            ammo -= 1;
            earRingingVolume = 1;
        }
        earRingingVolume -= 0.3f * Time.deltaTime;
        earRinging.volume = earRingingVolume;
    }
    private void OnDestroy()
    {
        Destroy(ammoUI);
    }
}
