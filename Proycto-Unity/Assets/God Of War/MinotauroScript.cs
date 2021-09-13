using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotauroScript : MonoBehaviour
{
    public Enemigo enemyScript;
    public GameObject axeShoulder, axeHand;
    public Animator animatorControler;

    void Start()
    {
        
    }

    void Update()
    {
        
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        
        OcultarHacha();
    }

    void OcultarHacha()
    {
        if (animatorControler.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Swagger Walk")
        {
            axeHand.SetActive(false);
            axeShoulder.SetActive(true);
        }
        else
        {
            axeHand.SetActive(true);
            axeShoulder.SetActive(false);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            animatorControler.SetTrigger("Ataque");
        }
    }
}
