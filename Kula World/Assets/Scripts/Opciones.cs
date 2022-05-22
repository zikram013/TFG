using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{

    private AudioSource Audio;

    public GameObject textoMusica;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void MusicController()
    {
        if (Audio.isPlaying)
        {
            if (textoMusica.name == "AudioNo")
            {
                textoMusica.SetActive(false);

            }
            if (textoMusica.name == "AudioSi")
            {
                textoMusica.SetActive(true);
            }
            Audio.Stop();

        }
        else 
        {
            if (textoMusica.name == "AudioSi")
            {
                textoMusica.SetActive(false);

            }
            if (textoMusica.name == "AudioNo")
            {
                textoMusica.SetActive(true);
            }
            Audio.Play();
        }
           
    }

    public void controlTexto() 
    {
        if (textoMusica.name == "AudioNo")
        {
            textoMusica.SetActive(false);
            if (textoMusica.name == "AudioSi")
            {
                textoMusica.SetActive(true);
            }
        }
        else 
        {
            textoMusica.SetActive(false);
            if (textoMusica.name == "AudioNo")
            {
                textoMusica.SetActive(true);
            }
        }
    }
}
