using UnityEngine;
using System.Collections;

public class GCFaseCaverna : GCFase {

    void Start() {
        var personagem = GameObject.FindGameObjectWithTag("Player");
        var luz = personagem.AddComponent<Light>() as Light;
        luz.intensity = 2f;
        personagem.transform.Translate(new Vector3(0, 0, -1));
    }
}
