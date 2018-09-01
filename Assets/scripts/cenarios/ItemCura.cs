using UnityEngine;
using System.Collections;

public class ItemCura : MonoBehaviour {

    [SerializeField]
    private int curaHP;

    [SerializeField]
    private int curaMP;

    void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Player")) {
            var personagem = colisor.gameObject.GetComponent<IPersonagem>();
            personagem.getStatus().recuperaHP(curaHP);
            personagem.getStatus().recuperaMagia(curaMP);
            Destroy(this.gameObject);
        }
    }
}
