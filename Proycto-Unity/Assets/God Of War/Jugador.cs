using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Animator animacionesJugador;

    public float distanciaEnemigoCercano;
    public GameObject player, enemigoCercano, pantallamuerte;
    public GameObject[] enemigos, espadasEnMano, espadasEnEspalda;

    public RectTransform barraVida;
    public int Vida, barraVidaXPos;

    public int minotaurDamage;

    public float[] distanciasEnemigos;
    void Start()
    {

    }
    void Update()
    {

        DetectarEnemigos();
        DetectarEspadas();

        if (Input.GetMouseButtonDown(0))
            animacionesJugador.SetTrigger("Ataque");

        barraVida.sizeDelta = new Vector2(Vida, barraVida.sizeDelta.y);
        barraVida.anchoredPosition = new Vector3( barraVidaXPos, barraVida.anchoredPosition.y);

        if(Vida <= 0)
        {
            Time.timeScale = 0;
            pantallamuerte.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Armas/HachaMinotauro"))
        {
            Vida -= minotaurDamage;
            barraVidaXPos += (minotaurDamage-15); //NO TOCAR ESTA PUTA MIERDA
        }
    }
    void DetectarEnemigos()
    {
        try
        {
            enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            Array.Resize(ref distanciasEnemigos, enemigos.Length);

            for(int index = 0; index < enemigos.Length;index++)
                distanciasEnemigos[index] = Vector3.Distance(player.transform.position, enemigos[index].transform.position);

            enemigoCercano = enemigos[Array.IndexOf(distanciasEnemigos, distanciasEnemigos.Min())];
            distanciaEnemigoCercano = distanciasEnemigos.Min();
        }
        catch { }
    }
    #region Funcionalidad Espadas
    void DetectarEspadas()
    {
        try
        {
            if (animacionesJugador.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Ataque" ||
                animacionesJugador.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Ataque2")
                OcultarEspadas(espadasEnEspalda, espadasEnMano);

            else
                OcultarEspadas(espadasEnMano, espadasEnEspalda);
        }
        catch { }
    }
    void OcultarEspadas(GameObject[] espadasOcultar, GameObject[] espadasMostrar)
    {
        foreach (var espada in espadasOcultar)
        {
            espada.SetActive(false);
        }
        foreach (var espada in espadasMostrar)
        {
            espada.SetActive(true);
        }
    }
    #endregion
}
