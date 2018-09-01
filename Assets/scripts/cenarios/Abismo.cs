using UnityEngine;
using System.Collections;

public class Abismo : MonoBehaviour {

    void OnTriggerExit2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Player")) {
            //Verifica se está abaixo do objeto com o script
            if (colisor.gameObject.transform.position.y < transform.position.y) {
                var personagem = colisor.gameObject.GetComponent<IPersonagem>();
                personagem.recebeDano(999); //mata o personagem
            }
        }
    }
}
