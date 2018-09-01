using UnityEngine;
using System.Collections;

public class Interruptor : MonoBehaviour {

    public Sprite interruptorAtivo;     // Sprite do Interruptor ativo
    public GameObject bloqueio;         // Desativa o objeto que bloqueia a passagem 

    void OnTriggerEnter2D (Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Player")) {
            GetComponent<SpriteRenderer>().sprite = interruptorAtivo; //Muda o Sprite
            bloqueio.SetActive(false);                                //Desativa o objeto que está bloqueando passagem

            var audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
