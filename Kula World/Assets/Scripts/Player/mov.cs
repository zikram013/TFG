using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{

    //public float xForce = 1f;
    //public float zForce = 10f;
    //public float yForce = 500f;
    public float speed;
    private Rigidbody rb;
    CharacterController controller;
    Vector3 posicionInicial;
    Vector3 posicionFinal;
    GameObject terreno;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(0,1,0);
        terreno = GameObject.FindWithTag("Mapa");
        
    }

    // Update is called once per frame
    void Update()
    {

       // float x = 0f;

        if (Input.GetKeyDown(KeyCode.S))
        {
            posicionInicial = transform.position;
            Vector3 destino = new Vector3(posicionInicial.x - 1, transform.position.y, transform.position.z);
            if (terreno.transform.position != destino)
            {
                transform.position = destino; 
            }
            else
            {
                Debug.Log("Se sale de los limites");
            }
            

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            posicionInicial = transform.position;
            Vector3 destino = new Vector3(posicionInicial.x + 1, transform.position.y, transform.position.z);
            transform.position = destino;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            posicionInicial = transform.position;
            Vector3 destino = new Vector3(transform.position.x, transform.position.y, posicionInicial.z + 1);
            transform.position = destino;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            posicionInicial = transform.position;
            Vector3 destino = new Vector3(transform.position.x, transform.position.y, posicionInicial.z  -1);
            transform.position = destino;
        }
    }
   

}
