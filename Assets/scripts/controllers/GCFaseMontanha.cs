using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GCFaseMontanha : GCFase {

    public override void finalizarFase()
    {
        SceneManager.LoadScene("Creditos");
    }
}
