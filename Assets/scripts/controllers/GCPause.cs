using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCPause : MonoBehaviour {

    public GameObject menu;
    private static bool pausado = false;

    public static bool getPausado()   {
        return pausado;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            menu.SetActive(true);
            Time.timeScale = 0f;
            pausado = true;
        }  
    }

    public void botaoVoltar() {
        Time.timeScale = 1f;
        pausado = false;
        menu.SetActive(false);

    }

    public void botaoMenuFases() {
        Time.timeScale = 1f;
        pausado = false;
        SceneManager.LoadScene("MenuFases");
    }

    public void botaoMenuPrincipal() {
        Time.timeScale = 1f;
        pausado = false;
        SceneManager.LoadScene("Main");
    }
}
