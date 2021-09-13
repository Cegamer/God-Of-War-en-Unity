using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbes : MonoBehaviour
{
    Jugador jugadorScript;

    // Start is called before the first frame update
    void Start()
    {
        jugadorScript = GameObject.FindGameObjectWithTag("PlayerScript").GetComponent<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (jugadorScript.Vida < 235)
            {
                jugadorScript.Vida += 25;
                jugadorScript.barraVidaXPos -= 12;
            }
            if(jugadorScript.Vida > 235)
            {
                jugadorScript.Vida = 235;
                jugadorScript.barraVidaXPos = 117;
            }

            Destroy(this.gameObject);
        }
    }
}
