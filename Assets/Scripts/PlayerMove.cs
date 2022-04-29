using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static Vector3 lastLoct;
    [SerializeField] private GameObject dest;
    //[SerializeField] private GameObject isocam;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float xInput;
    [SerializeField] private float zInput;
    [SerializeField] private FixedJoystick joystick;
    public GameObject Player;
    private Rigidbody rb;
    [SerializeField] private Transform Cam;
    private float x, z;//dir
    bool isGround = true;
    
    private void LateUpdate()
    {
        x = Player.GetComponent<Transform>().position.x - Cam.position.x;
        z = Player.GetComponent<Transform>().position.z - Cam.position.z;
        //dir = Mathf.Sin(x / z);
        //Debug.Log("dir:"+dir + "x:" + x + "z:" + z);
    }
    private void Awake()
    {
        rb = Player.GetComponent<Rigidbody>();
        //target = Player.GetComponent<Transform>();
    }
    void Update()
    {
        ProcessInputs();
    }
    private void FixedUpdate()
    {
        Move();
        //isocam.transform.position = new Vector3(transform.position.x - 5, transform.position.y + 6, transform.position.z - 3);
    }
    private void ProcessInputs()
    {
        //xInput = joystick.Horizontal;
        //zInput = joystick.Vertical;
        //Debug.Log(xInput+"  "+ zInput);
        if (z >= 4.5f) //&& x == 0)
        {
            xInput = joystick.Horizontal;
            zInput = joystick.Vertical;
        }
        else if (x <= -4.5f)  //&& z == 0)
        {
            xInput = -joystick.Vertical;
            zInput = joystick.Horizontal;
        }
        else if (z <= -4.5f)  //&& x == 0)
        {
            xInput = -joystick.Horizontal;
            zInput = -joystick.Vertical;
        }
        else if (x >= 4.5f)  //&& z == 0)  
        {
            xInput = joystick.Vertical;
            zInput = -joystick.Horizontal;
        }
        //xInput = Input.GetAxis("Horizontal");
        //zInput = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }
    public void Jump()
    {
        if (isGround)
        {
            Vector3 jump = new Vector3(xInput, 40, zInput);
            rb.AddForce(jump * moveSpeed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(Instantiate(dest, transform.position, transform.rotation), 3f);
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            //gameObject.GetComponent<Rigidbody>().useGravity = false;
            StartCoroutine(Respawn());
        }
        if (collision.collider.gameObject.tag == "Moveingplat")
        {
            gameObject.transform.parent = collision.collider.gameObject.transform;

        }
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        gameObject.transform.position = lastLoct;
        //gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.localScale = new Vector3(100f, 100f, 100f);
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.gameObject.tag == "Ground")
    //    {

    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastLoct = other.gameObject.transform.position;
            lastLoct.y += 1f;
            isGround = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Moveingplat")
        {
            gameObject.transform.parent = null;
        }
    }
}
