using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject characters;
    public List<GameObject> listCharacters = new List<GameObject>();

    private void Awake()
    {

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
