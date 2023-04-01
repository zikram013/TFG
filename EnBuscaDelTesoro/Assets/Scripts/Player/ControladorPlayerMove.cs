using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPlayerMove : MonoBehaviour
{


    public float yForce = 500f;
    private Rigidbody rb;
    public float speed;
    public float maxSpeed;
    public GameObject referencia;
    CharacterController controller;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()

    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float y = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }

        GetComponent<Rigidbody>().AddForce(0, y, 0);
         float moverHorizontal = Input.GetAxis("Horizontal");
         float moverVertical = Input.GetAxis("Vertical");
         if (rb.velocity.magnitude > maxSpeed)
         {
             rb.velocity = rb.velocity.normalized * maxSpeed;
         }
         rb.AddForce(moverVertical * referencia.transform.forward * speed);
         rb.AddForce(moverHorizontal * referencia.transform.right * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tesoro")
        {
            Destroy(collision.gameObject);
        }
    }
}
