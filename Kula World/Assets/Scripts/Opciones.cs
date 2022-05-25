using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{

    private AudioSource Audio;

    //Botones de audio
    public GameObject botonMusicaOn;
    public GameObject botonMusicaOff;

    //Botones de sonido
    public GameObject botonIdiomaESP;
    public GameObject botonIdiomaING;


    // Start is called before the first frame update
    void Start()
    {
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    //public void MusicController()
    //{
    //    if (Audio.isPlaying)
    //    {
    //        if (textoMusica.name == "AudioNo")
    //        {
    //            textoMusica.SetActive(false);

    //        }
    //        if (textoMusica.name == "AudioSi")
    //        {
    //            textoMusica.SetActive(true);
    //        }
    //        Audio.Stop();

    //    }
    //    else 
    //    {
    //        if (textoMusica.name == "AudioSi")
    //        {
    //            textoMusica.SetActive(false);

    //        }
    //        if (textoMusica.name == "AudioNo")
    //        {
    //            textoMusica.SetActive(true);
    //        }
    //        Audio.Play();
    //    }
           
    //}

    //Add encender o apagar la musica
    public void controlBotonVolumen() 
    {

        if (botonMusicaOff.activeSelf)
        {
        
            botonMusicaOff.SetActive(false);
            Audio.Stop();
            botonMusicaOn.SetActive(true);
        }
        else 
        {
            botonMusicaOn.SetActive(false);
            Audio.Play();
            botonMusicaOff.SetActive(true);
        }  
    }

    //Add traduccion del juego
    public void controlBotonIdioma() 
    {
        if (botonIdiomaING.activeSelf)
        {
            botonIdiomaING.SetActive(false);
            botonIdiomaESP.SetActive(true);
        }
        else 
        {
            botonIdiomaESP.SetActive(false);
            botonIdiomaING.SetActive(true);
        }
    }
}
