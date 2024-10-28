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
    public AudioSource footsteps;
    public bool canStep;
    public AudioClip step;
    public GameObject interactionIndicator;
    public Animator myAnim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gM = GameObject.Find("GameManager");
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            myAnim.SetBool("walking", true);
        }
        else
        {
            myAnim.SetBool("walking", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnim.SetBool("shift held", true);
        }
        else
        {
            myAnim.SetBool("shift held", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            myAnim.SetTrigger("shoot");
        }
        if (touchingButton)
        {
            interactionIndicator.SetActive(true);
        }
        else
        {
            interactionIndicator.SetActive(false);
        }

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && canStep)
        {
            StartCoroutine(Footsteps());
        }
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
            touchingButton = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            gM.GetComponent<gameManager>().IncreaseLevel();
        }
    }
    IEnumerator Footsteps()
    {
        canStep = false;
        footsteps.pitch = Random.Range(0.7f, 1.3f);
        footsteps.PlayOneShot(step);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.4f));
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(0.4f, 0.5f));
        }
        canStep = true;
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
