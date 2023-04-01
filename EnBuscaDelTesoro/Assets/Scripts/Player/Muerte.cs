using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Muerte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().Death();
        }
    }
}
