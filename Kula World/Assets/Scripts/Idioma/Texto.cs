using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texto : MonoBehaviour
{

    public string esp;
    public string ing;
    public bool isBoton;
    public GameObject botonIdiomaESP;
    public GameObject botonIdiomaING;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarIdioma() 
    {
        //cambia a ingles
        if (botonIdiomaING.activeSelf)
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = ing;
            }
            else 
            {
                GetComponent<TMP_Text>().text = ing;
            }
        }
        else if (botonIdiomaESP.activeSelf) 
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = esp;
            }
            else 
            {
                GetComponent<TMP_Text>().text = esp;
            }
        }
        

        
    }
}
