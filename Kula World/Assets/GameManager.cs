using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject characters;
    public List<GameObject> listCharacters = new List<GameObject>();

 

    private void Awake()
    {
        //if (FindObjectsOfType(GetType()).Length > 1)
        //{
        //    Destroy(gameObject);
        //}

        //if (sonidoEscenas != null && sonidoEscenas != this)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //else
        //{
        //    sonidoEscenas = sonidoEscenas;
        //}

        DontDestroyOnLoad(this.gameObject);
        
    }
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

    public void selectCharacter(int character) 
    {
        Debug.Log(character);
        characters = listCharacters[character];
        Debug.Log("characeter select is: " + characters.name);
    }


}
