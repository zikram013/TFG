using System;
using NotificationCenter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texto : MonoBehaviour
{

    public string espanol;
    public string ingles;
    public bool isBoton;

    //public ListaIdiomas lista;
  
    // Start is called before the first frame update
    void Start()
    {
        //NotificationCenterManager.Instance.AddObserver(OnNotification,"CambiarIdioma_");
        //CambiarIdioma_();
        if (Idioma.Instance.RetornaIdioma()=="Ingles")
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = ingles;
            }
            else 
            {
                GetComponent<TMP_Text>().text = ingles;
            }
        }
        else if (Idioma.Instance.RetornaIdioma() == "Espanol") 
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = espanol;
            }
            else 
            {
                GetComponent<TMP_Text>().text = espanol;
            }
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Idioma.OnLanguageChange += CambiarIdioma;
    }

   void OnDestroy()
    {
        Idioma.OnLanguageChange -= CambiarIdioma;
    }

    public void CambiarIdioma(ListaIdiomas idioma) 
    {
        //cambia a ingles
        if (Idioma.Instance.RetornaIdioma()=="Ingles")
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = ingles;
            }
            else 
            {
                GetComponent<TMP_Text>().text = ingles;
            }
        }
        else if (Idioma.Instance.RetornaIdioma() == "Espanol") 
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = espanol;
            }
            else 
            {
                GetComponent<TMP_Text>().text = espanol;
            }
        }
        

        
    }

    
}
