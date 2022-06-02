using NotificationCenter;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Idioma : MonoBehaviour
{
    public GameObject BotonIdiomaESP;
    public GameObject BotonIdiomaING;
    private static string idiomaActual = "Español";
    private void Start()
    {
        
        CambiarIdioma(idiomaActual);
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        if (this.gameObject.activeSelf == true) 
        {
            DontDestroyOnLoad(transform.gameObject);
        } 
        
    }

    public string RetornaIdioma() 
    {
        return (idiomaActual);
    }

    public void CambiarIdioma(string idioma) 
    {
        Debug.Log(idioma);
        idiomaActual = idioma;
        Notification notification = new Notification(this, idioma);
        NotificationCenterManager.Instance.PostNotification("CambiarIdioma_", notification);
        //NotificationCenter.NotificationCenterManager.Instance.PostNotification("CambiarIdioma_");
    }
}
