using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{

    private AudioSource Audio;

    private Canvas canvas;
    

    //Botones de audio
    public GameObject botonMusicaOn;
    public GameObject botonMusicaOff;


   


    // Start is called before the first frame update
    void Start()
    {
        //Posiblemente toque buscar todos si queremos quitar la musica del nivel
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>(); ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string name)
    {
        canvas.gameObject.SetActive(false);
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
        if (Idioma.Instance.idiomaActual == "Espanol")
        {
            Idioma.Instance.CambiarIdioma(ListaIdiomas.Ingles);
        }
        else 
        {
            Idioma.Instance.CambiarIdioma(ListaIdiomas.Espanol);
        }
    }
}
