using NotificationCenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Idioma : MonoBehaviour
{
   
    public ListaIdiomas ListaIdiomas;
    public static event Action<ListaIdiomas> OnLanguageChange; 
    public static Idioma Instance;

    public  string idiomaActual = "Espanol";
    private void Start()
    {
        //CambiarIdioma(idiomaActual);
    }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(base.gameObject);
        }
        else
        {
            
            Destroy(base.gameObject);
            //Instance = this;
        }
        
    }

    public string RetornaIdioma() 
    {
        return (idiomaActual);
    }

    public void CambiarIdioma(ListaIdiomas newIdioma) 
    {
        switch (newIdioma)
        {
            case ListaIdiomas.Espanol:
                idiomaActual = "Espanol";
                break;
            case ListaIdiomas.Ingles:
                idiomaActual = "Ingles";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newIdioma), newIdioma, null);
        }
       
        OnLanguageChange?.Invoke(newIdioma);
       
    }

    
}


public enum ListaIdiomas
{
    Espanol,
    Ingles
}
