using UnityEngine;
using System.Collections;

public class AtaqueAndante : Ataque {

    public bool direita = true; //Direção do movimento e sprite
    public float velocidade;    //velocidade do movimento
     
	void Update () {
        if (!direita) {
            var z = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(0, 180, z); //Invertemos o eixo Y
        }

        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
	}
}
