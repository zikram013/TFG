using NotificationCenter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texto : MonoBehaviour
{

    public string español;
    public string ingles;
    public bool isBoton;


    public Idioma IdiomaGlobal;
    // Start is called before the first frame update
    void Start()
    {
        NotificationCenterManager.Instance.AddObserver(OnNotification,"CambiarIdioma_");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        IdiomaGlobal = GameObject.Find("Canvas").GetComponent<Idioma>();
    }

    public void CambiarIdioma_() 
    {
        //cambia a ingles
        if (IdiomaGlobal.RetornaIdioma()=="Ingles")
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
        else if (IdiomaGlobal.RetornaIdioma() == "Español") 
        {
            if (isBoton)
            {
                GetComponentInChildren<TMP_Text>().text = español;
            }
            else 
            {
                GetComponent<TMP_Text>().text = español;
            }
        }
        

        
    }

    private void OnNotification(Notification p_notification)
    {
        CambiarIdioma_();
    }
}
