using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectPlayerButton : MonoBehaviour
{
    public void selectCharacters(int character) 
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().selectCharacter(character);

    }

    public void loadLevel(string level) 
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().LoadLevel(level);

    }

}
