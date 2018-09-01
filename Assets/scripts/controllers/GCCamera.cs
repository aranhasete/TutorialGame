using UnityEngine;
using System.Collections;

public class GCCamera : MonoBehaviour {

    public Transform alvo;      //Quem a camera segue
    public float velocidade;    //Com qual velocidade a camera segue

    public float minX = -9999;
    public float maxX = 9999;
    public float minY = -9999;
    public float maxY = 9999;

    void Start() {
        if (PlayerPrefs.GetInt("volume") == 1)
            habilitarSom();
        else
            desabilitarSom();
    }

    void Update() {

        if (alvo != null) {
            var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
        }

        //Limite
        var camera = GetComponent<Camera>();
        if (camera.orthographic) { 
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            var alcanceHorizontal = camera.orthographicSize * Screen.width / Screen.height;

            var realMinX = minX + alcanceHorizontal;
            var realMaxX = maxX - alcanceHorizontal;

            x = Mathf.Clamp(x, realMinX, realMaxX); 
            y = Mathf.Clamp(y, minY, maxY);

            transform.position = new Vector3(x, y, z);
        }
    }

    public void habilitarSom() {
        AudioListener.volume = 1f;                      //Audio do jogo em 100%
        //GetComponent<AudioListener>().enabled = true; //Não funciona no Build, apenas no Editor
    }

    public void desabilitarSom() {
        AudioListener.volume = 0;                        //Audio do jogo em 0%
        //GetComponent<AudioListener>().enabled = false; //Não funciona no Build, apenas no Editor
    }
}
