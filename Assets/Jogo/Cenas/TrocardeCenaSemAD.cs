using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocardeCenaSemAD : MonoBehaviour
{
    public string nomeDaCena;
    public void MudarDeCena()
    {
        SceneManager.LoadScene(nomeDaCena);

    }
}
