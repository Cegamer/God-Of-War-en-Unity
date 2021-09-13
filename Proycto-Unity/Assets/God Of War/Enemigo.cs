using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemigo : MonoBehaviour
{
    public float vida;
    public float damageRecieved;
    public GameController controladorPuntaje;

    public Transform Jugador, barravida;
    public NavMeshAgent nvMesh;
    void Start()
    {
        controladorPuntaje = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nvMesh = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        nvMesh.SetDestination( Jugador.position);
        barravida.localScale = new Vector3(vida, barravida.localScale.y, barravida.localScale.z);

        if (vida <= 0) {

            controladorPuntaje.puntaje++;
            Destroy(this.gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arma")) vida -= damageRecieved;
    }
}
