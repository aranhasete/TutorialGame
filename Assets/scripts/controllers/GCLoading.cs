using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GCLoading : MonoBehaviour {

    private AsyncOperation carregamento;
    public Slider barraDeProgresso;

    void Start () {
        var scene = FindObjectOfType<GCJogo>().sceneLoading;
        carregamento = SceneManager.LoadSceneAsync(scene);
	}
	
	void Update () {
        barraDeProgresso.value = carregamento.progress;
    }
}
