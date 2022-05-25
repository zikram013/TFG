using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptAudio : MonoBehaviour
{

    private AudioSource sonidoEscenas;

    public static ScriptAudio Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        sonidoEscenas = new AudioSource(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1) 
        {
            Destroy(gameObject);
        }

        if (sonidoEscenas != null && sonidoEscenas != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void MusicController()
    {
        Debug.Log("entro en el controller");

        if (sonidoEscenas.isPlaying)
        {
            sonidoEscenas.Stop();
        }

        if (!sonidoEscenas.isPlaying)
        {
            sonidoEscenas.Play();
        }
    }
}
