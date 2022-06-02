using NotificationCenter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
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
    }

    private void Awake()
    {
    }

   



}
