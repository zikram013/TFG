using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAudio : MonoBehaviour
{

    private ScriptAudio sonidoEscenas;
    private ScriptAudio Instance 
    {
        get 
        {
           return sonidoEscenas;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
        else 
        {
            sonidoEscenas = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    //public void MusicController() 
    //{
    //    if (sonidoEscenas.isPlaying) 
    //    {
    //        sonidoEscenas.Stop();
    //    }

    //    if (!sonidoEscenas.isPlaying) 
    //    {
    //        sonidoEscenas.Play();
    //    }
    //}
}
