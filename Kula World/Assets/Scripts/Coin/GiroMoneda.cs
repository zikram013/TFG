using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroMoneda : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30f, 0f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().numberTreasure++;
            gameObject.SetActive(false);
        }
    }

}
