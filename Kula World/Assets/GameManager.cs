using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject characters;
    public List<GameObject> listCharacters = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(base.gameObject);
        }
        else
        {
            
            Destroy(base.gameObject);
            //Instance = this;
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