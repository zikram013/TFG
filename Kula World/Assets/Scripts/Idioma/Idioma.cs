using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Idioma : MonoBehaviour
{

    public string idiomaActual = "Español";
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void CambiarIdioma(string idioma) 
    {
        idiomaActual = idioma;
    }
}
