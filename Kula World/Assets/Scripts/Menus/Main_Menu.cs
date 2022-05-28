using NotificationCenter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public Idioma IdiomaGlobal;
    public GameManager game;

    public string español;
    public string ingles;
    public bool isBoton;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }


    public void Start()
    {
        NotificationCenterManager.Instance.AddObserver(OnNotification, "CambiarIdioma_");
    }

    private void Awake()
    {
        IdiomaGlobal = GameObject.Find("Canvas").GetComponent<Idioma>();
    }

    public void CambiarIdioma_()
    {
        //cambia a ingles
        if (IdiomaGlobal.RetornaIdioma() == "Ingles")
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
