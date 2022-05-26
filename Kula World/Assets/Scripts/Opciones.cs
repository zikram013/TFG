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
        //Posiblemente toque buscar todos si queremos quitar la musica del nivel
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
