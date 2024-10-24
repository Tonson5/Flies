using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float moveSpeed;
    public float playerWalkSpeed;
    public float playerRunSpeed;
    private Rigidbody rb;
    private bool touchingButton;
    public GameObject button;
    public GameObject gM;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gM = GameObject.Find("GameManager");
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = playerRunSpeed;
        }
        else
        {
            moveSpeed = playerWalkSpeed;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(button);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            gM.GetComponent<gameManager>().IncreaseLevel();
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * moveSpeed * Input.GetAxisRaw("Vertical"));
        rb.AddForce(Vector3.right * moveSpeed * Input.GetAxisRaw("Horizontal"));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            touchingButton = true;
            button = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            touchingButton = false;
            button = null;

        }
    }
    private void OnDestroy()
    {
        gM.GetComponent<gameManager>().Lose();
    }
}
