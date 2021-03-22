using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSeguimiento : MonoBehaviour
{

    public GameObject player;
    public GameObject referencia;
    private Vector3 distancia;

    // Start is called before the first frame update
    void Start()
    {
        //Calculamos la distancia entre la posicion del jugador y la posicion de la camara
        distancia = transform.position - player.transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
        
        transform.position = player.transform.position + distancia;
        transform.LookAt(player.transform.position);

        //Evitamos el cambio de los controles
        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        referencia.transform.eulerAngles = copiaRotacion;

    }
}
