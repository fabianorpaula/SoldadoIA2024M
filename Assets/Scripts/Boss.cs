using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private NavMeshAgent Agente;
    public GameObject Heroi;
    private Animator Anim;
    
    public enum Estados { Mover, Atacar, Parado};
    public Estados MeuEstado;

    void Start()
    {
        MeuEstado = Estados.Parado;
        Agente = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*
       float distance = Vector3.Distance(transform.position, 
           Heroi.transform.position);
        if(distance < 5)
        {
            Anim.SetBool("Andar", false);
        }
        else
        {
            Anim.SetBool("Andar", true);
        }
        
        
        Agente.SetDestination(Heroi.transform.position);
        */

        Logica();
    }

    public void Logica()
    {
        if(MeuEstado == Estados.Parado)
        {
            Esperando();
        }

        if(MeuEstado == Estados.Mover)
        {
            Movimento();
        }
        if(MeuEstado == Estados.Atacar)
        {
            Atacando();
        }
    }

    void Esperando()
    {
        Agente.speed = 0;
        Anim.SetBool("Andar", false);
        ZeraAtaque();
    }

    public void Movimento()
    {
        Agente.SetDestination(Heroi.transform.position);
        Agente.speed = 5;
        Anim.SetBool("Andar", true);
        ZeraAtaque();
    }

    void ZeraAtaque()
    {
        Anim.SetBool("AtaqueLeve", false);
        Anim.SetBool("AtaquePesado", false);
        Anim.SetBool("AtaqueDistancia", false);
    }

    public void Atacando()
    {
        Agente.speed = 0;
        Anim.SetBool("Andar", false);
        float distancia = Vector3.Distance(transform.position,
            Heroi.transform.position);
        if(distancia > 5) {
            Anim.SetBool("AtaqueDistancia", true);
        }
        else
        {
            float sorteio = Random.Range(0, 10);
            if(sorteio > 8) {
                Anim.SetBool("AtaquePesado", true);
            }
            else
            {
                Anim.SetBool("AtaqueLeve", true);
            }
        }
    }
}
