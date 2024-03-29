using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public enum estados
    {
        loading, commands, playing, paused, finish, quit
    }

    public TMP_Text totalmoves;
    public GameObject imgTarget;
    public estados states;
    public int lives;
    public TMP_Text livesText;
    public GameObject[] tesoro;
    private GameObject jugador;
    public int maxTreasure;
    public int maxMovements;
    public int numberMovements;
    public int numberTreasure;
    public TMP_Text textoComandos;
    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject mapeado;
    public GameObject menuSiguienteNivel;
    public Vector3 InicializaPosicion;//new Vector3(0, 0.5F, -2)
    public GameObject botonGanar;
    public GameObject botonPerder;
    public GameObject textoDerrota;
    public GameObject textoVictoria;
    
    

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;
    private string[] listMove;
    private int size = 0;
    private bool ejecutar = false;
    private string movement = "";
    private bool flag = true;
    private bool final = false;
    private bool dead = false;
    private GameObject[] MapaCubos;
    private List<Vector3> MapaCoordenadas;
    private int numeroTesorosActual;
    private int auxMoves;


    // Start is called before the first frame update
    void Start()
    {

        //jugador.transform.localPosition =InicializaPosicion;
        //jugador.transform.position = InicializaPosicion;
        //jugador.transform.position = posicionAux;
        //jugador.transform.localPosition = posicionAux;
        /*MapaCubos = GameObject.FindGameObjectsWithTag("Mapa");
        foreach (var mapa in MapaCubos)
        {
            MapaCoordenadas.Add(mapa.transform.position);
        }*/
        
        
        jugador = Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().characters, InicializaPosicion, Quaternion.EulerAngles(0, 360, 0));
        
        var posicionAux = jugador.transform.position;
        //jugador.transform.SetParent(imgTarget.transform,true); 
        
        posicionInicial = InicializaPosicion;
        rotacionInicial = jugador.transform.rotation;
        jugador.transform.SetParent(mapeado.transform,true);
        jugador.transform.localPosition = posicionInicial;
        maxTreasure = tesoro.Length;
        textoComandos.text = "";
        totalmoves.text = "MOVS: " + maxMovements;
        auxMoves = maxMovements;
        states = estados.loading;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (states)
        {
            case estados.loading:
                
                foreach (GameObject tes in tesoro)
                {
                    tes.SetActive(true);
                }
                jugador.transform.position = InicializaPosicion;
                //jugador.transform.localPosition = InicializaPosicion;
                jugador.transform.rotation = rotacionInicial;
                //jugador.transform.SetParent(imgTarget.transform,true);
                jugador.transform.localPosition = InicializaPosicion;
                tesoro = GameObject.FindGameObjectsWithTag("Tesoro");
                maxMovements= auxMoves;
                totalmoves.text = "MOVS: " + auxMoves;
                maxTreasure = tesoro.Length;
                textoComandos.text = " ";
                numberTreasure = 0;
                numberMovements = 0;
                ejecutar = false;
                final = false;
                movement = "";
                livesText.text = lives.ToString();
                dead = false;
                states = estados.commands;
                break;
            case estados.commands:

                if (ejecutar)
                {
                    size = 0;
                    listMove = movement.Split(',');
                    states = estados.playing;
                }

                break;
            case estados.playing:
                if (size < listMove.Length - 1)
                {
                    if (flag)
                    {
                        
                        StartCoroutine(movimiento(listMove[size]));
                       
                        flag = false;
                    
                    }
                }
                //Control del movimiento
                if (numberTreasure == maxTreasure)
                {
                    int contador = 0;
                    while (contador < 3)
                    {
                        jugador.GetComponent<Animator>().SetBool("jumping",true);
                        contador++;
                        jugador.GetComponent<Animator>().SetBool("jumping",false);
                    }

                    
                    states = estados.finish;
                    
                }

                if (lives > 0)
                {
                   
                    if (numberTreasure < maxTreasure && flag == false && size == listMove.Length-1)
                    {
                        lives--;
                        states = estados.loading;
                    }

                }
                else
                {
                    dead = true;
                    states = estados.finish;
                }
                
                break;
            case estados.paused:
                break;
            case estados.finish:
               
                if (dead)
                {
                    Debug.Log("Perdiste");
                    menuSiguienteNivel.SetActive(true);
                    botonPerder.SetActive(true);
                    textoDerrota.SetActive(true);
                    
                }
                else
                {
                    Debug.Log("Ganaste");
                    menuSiguienteNivel.SetActive(true);
                    botonGanar.SetActive(true);
                    textoVictoria.SetActive(true);
                }

                break;

            case estados.quit:
                //OnDestroy();
                Time.timeScale = 1f;
                //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                menuSiguienteNivel.SetActive(false);
                menuPausa.SetActive(false);
                SceneManager.LoadScene("MenuPrincipal");
                //posicionInicial = InicializaPosicion;

                break;
            default:
                break;
        }
    }


    private IEnumerator movimiento(string letra)
    {
        size++;
        
        if (letra != " ")
        {
            Vector3 destino = Vector3.zero;
            Quaternion destinoRotacion = Quaternion.EulerAngles(0,0,0);
            
            if (letra.Equals("↑"))
            {
                destino = new Vector3(jugador.transform.position.x + 1, jugador.transform.position.y, jugador.transform.position.z);
                if (jugador.transform.rotation.y != 360)
                {
                    destinoRotacion = Quaternion.EulerAngles(0,360,0);
                }
            }
            if (letra.Equals("↓"))
            {
                destino = new Vector3(jugador.transform.position.x - 1, jugador.transform.position.y, jugador.transform.position.z);
                if (jugador.transform.rotation.y != -360)
                {
                    destinoRotacion = Quaternion.EulerAngles(0,-360,0);
                }
            }
            if (letra.Equals("→"))
            {
                destino = new Vector3(jugador.transform.position.x, jugador.transform.position.y, jugador.transform.position.z - 1);
                if (size == 1)
                {
                    destinoRotacion = Quaternion.EulerAngles(0,jugador.transform.rotation.y-45,0);
                }
                if (size > 1)
                {
                    if (listMove[size - 2] != letra )
                    {
                        destinoRotacion = Quaternion.EulerAngles(0,jugador.transform.rotation.y-45,0);
                    }
                    else
                    {
                        destinoRotacion = jugador.transform.rotation;
                    }
                }
            }
            if (letra.Equals("←"))
            {
                destino = new Vector3(jugador.transform.position.x, jugador.transform.position.y, jugador.transform.position.z + 1);
                if (size == 1)
                {
                    destinoRotacion = Quaternion.EulerAngles(0,jugador.transform.rotation.y+45,0);
                }
                if (size > 1)
                {
                    if (listMove[size - 2] != letra )
                    {
                        destinoRotacion = Quaternion.EulerAngles(0,jugador.transform.rotation.y+45,0);
                    }
                    else
                    {
                        destinoRotacion = jugador.transform.rotation;
                    }
                }
            }
            jugador.GetComponent<Animator>().SetBool("walking",true);
            jugador.transform.position = destino;
            jugador.transform.rotation = destinoRotacion;
        }
        yield return new WaitForSeconds(1);
        jugador.GetComponent<Animator>().SetBool("walking",false);
        flag = true;

    }




    
    
    /*
        Vector3 aux = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 0.5F,
            jugador.transform.position.z); 
        if (!MapaCoordenadas.Contains(aux))
        {
            lives--;
            states = estados.loading;
        }*/

    public void adelante()
    {

        if (numberMovements < auxMoves)
        {
            movement += "↑,";
            textoComandos.text += "↑,";
            numberMovements++;
            maxMovements--;
            totalmoves.text = "MOVS: " + maxMovements;
        }

        
    }
    public void atras()
    {
        if (numberMovements < auxMoves)
        {
            movement += "↓,";
            textoComandos.text += "↓,";
            numberMovements++;
            maxMovements--;
            totalmoves.text = "MOVS: " + maxMovements;
        }

        
    }
    public void izquierda()
    {

        if (numberMovements < auxMoves)
        {
            movement += "←,";
            textoComandos.text += "←,";
            numberMovements++;
            maxMovements--;
            totalmoves.text = "MOVS: " + maxMovements;
        }

        
    }
    public void derecha()
    {

        if (numberMovements < auxMoves)
        {
            movement += "→,";
            textoComandos.text += "→,";
            numberMovements++;
            maxMovements--;
            totalmoves.text = "MOVS: " + maxMovements;
        }
        
    }

    public void jugar()
    {
        ejecutar = true;
    }

    public void Death()
    {
        lives--;
        livesText.text = lives.ToString();

        if (lives != 0)
        {
            states = estados.loading;
        }
        else
        {
            states = estados.finish;
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        Debug.Log("Juego Pausado");
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

    }

    public void Restart()
    {
        //lives = 3;
        //states = estados.loading;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        menuSiguienteNivel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Quit()
    {
        states = estados.quit;
    }

    public void SiguienteNivel(string name)
    {
        Debug.Log("Fin nivel");
        SceneManager.LoadScene(name);
        menuSiguienteNivel.SetActive(false);
        
    }

   
}