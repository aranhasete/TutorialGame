using UnityEngine;
using System.Collections;

public class EventoBoss : MonoBehaviour {

    [SerializeField]
    private new AudioClip audio;

    void OnTriggerExit2D(Collider2D colisor) {
        if (colisor.tag.Equals("Player")) {
            if (colisor.transform.position.x > transform.position.x) {

                var collider = GetComponent<BoxCollider2D>();
                collider.isTrigger = false;

                var camera = FindObjectOfType<GCCamera>();
                camera.minX = colisor.transform.position.x - 2f;

                //Troca o audio da Scene
                var audioFase = GameObject.Find("GC").GetComponent<AudioSource>();
                audioFase.clip = audio;
                audioFase.Play();
                
            }
        }
    }
}
