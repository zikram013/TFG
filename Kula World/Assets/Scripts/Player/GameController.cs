using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    
    public enum estados
    {
        loading,commands,playing,paused,finish
    }
    public estados states;

    public GameObject [] tesoro;
    public GameObject jugador;
    public int maxTreasure;
    public int maxMovements;
    public int numberMovements;
    public int numberTreasure;
    public TMP_Text textoComandos;

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private string[] listMove;
    private int size = 0;
    private bool ejecutar=false;
    private string movement = "";
    private bool flag = true;
    private bool final = false;


    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = jugador.transform.position;
        rotacionInicial = jugador.transform.rotation;
        maxTreasure = tesoro.Length;
        states = estados.loading;
    }

    // Update is called once per frame
    void Update()
    {
        switch (states)
        {
            case estados.loading:
                foreach(GameObject tes in tesoro)
                {
                    tes.SetActive(true);
                }
                jugador.transform.position = posicionInicial;
                jugador.transform.rotation = rotacionInicial;
                tesoro = GameObject.FindGameObjectsWithTag("Tesoro");
                maxTreasure = tesoro.Length;
                textoComandos.text = " ";
                numberTreasure = 0;
                numberMovements = 0;
                ejecutar = false;
                final = false;
                movement = "";
                states = estados.commands;
                break;
            case estados.commands:

                if (ejecutar)
                {
                    size = 0;
                    listMove = movement.Split(',');
                    states = estados.playing;
                }   

                break;
            case estados.playing:
                
                if (size < listMove.Length - 1)
                {
                    if (flag)
                    {
                        flag = false;
                        StartCoroutine(movimiento(listMove[size]));
                        
                    }
                }

                if(numberTreasure== maxTreasure)
                {
                    states = estados.finish;
                }
                else
                {

                }
                if (size == numberMovements)
                {
                    states = estados.loading;
                }


                break;
            case estados.paused:
                break;
            case estados.finish:
                Debug.Log("Ganaste");
                break;
            default:
                break;
        }
    }


    private IEnumerator movimiento(string letra)
    {
        if (letra!=" ")
        {
            Vector3 destino = Vector3.zero;


            if (letra.Equals("w"))
            {
                destino = new Vector3(jugador.transform.position.x + 1, jugador.transform.position.y, jugador.transform.position.z);
            }
            if (letra.Equals("s"))
            {
                destino = new Vector3(jugador.transform.position.x - 1, jugador.transform.position.y, jugador.transform.position.z);
            }
            if (letra.Equals("d"))
            {
                destino = new Vector3(jugador.transform.position.x, jugador.transform.position.y, jugador.transform.position.z - 1);
            }
            if (letra.Equals("a"))
            {
                destino = new Vector3(jugador.transform.position.x, jugador.transform.position.y, jugador.transform.position.z + 1);
            }
            Debug.Log(destino);

            jugador.transform.position = destino;
            
        }

        
        yield return new WaitForSeconds(1f);
        size++;


        flag = true;

    }





    public void adelante()
    {

        if (numberMovements < maxMovements)
        {
            movement += "w,";
            textoComandos.text += "w,";
            numberMovements++;
        }


        Debug.Log(movement);
    }
    public void atras()
    {
        if (numberMovements < maxMovements)
        {
            movement += "s,";
            textoComandos.text += "s,";
            numberMovements++;
        }
       

        Debug.Log(movement);
    }
    public void izquierda()
    {

        if (numberMovements < maxMovements)
        {
            movement += "a,";
            textoComandos.text += "a,";
            numberMovements++;
        }
        

        Debug.Log(movement);
    }
    public void derecha()
    {

        if (numberMovements < maxMovements)
        {
            movement += "d,";
            textoComandos.text += "d,";
            numberMovements++;
        }

        Debug.Log(movement);
    }

    public void jugar()
    {
        ejecutar = true;
    }

    public void Death()
    {
        states = estados.loading;
    }
    
}
