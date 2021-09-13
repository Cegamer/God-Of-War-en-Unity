using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject[] SpawnsEnemigos, SpawnsOrbes, Enemigos;
    public Jugador jugadorScript;
    public Text puntajeTexto;
    public int puntaje, enemigosMaximos;
    public float segundos, segundosOld;
    public GameObject orbesDeVida;
    void Start()
    {
        segundosOld = segundos;

    }
    void Update()
    {
        puntajeTexto.text = puntaje.ToString();
        Temporizador();
    }

    public void Temporizador()
    {
        if (segundos > 0)
            segundos-= 1 * Time.deltaTime;
        else { segundos = segundosOld;  SpawnearEnemigos(); SpawnearOrbes(); }
    }

    public void SpawnearEnemigos() { 

        if(jugadorScript.enemigos.Length <= enemigosMaximos)
        {
            var spawnAUsar = Random.Range(0, SpawnsEnemigos.Length);
            var enemigoASpawnear = Random.Range(0, Enemigos.Length);

            Instantiate(Enemigos[enemigoASpawnear],SpawnsEnemigos[spawnAUsar].transform.position,Quaternion.identity);

        }
    }
    public void SpawnearOrbes() { var spawnAUsar = Random.Range(0, SpawnsOrbes.Length);
        Instantiate(orbesDeVida, SpawnsOrbes[spawnAUsar].transform.position, Quaternion.identity);
    }
}
