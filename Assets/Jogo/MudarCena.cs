using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    public string nomeDaCena;
    public void MudarDeCena()
    {
        MonetizationManager.Instance.ShowInterstitial();
        SceneManager.LoadScene(nomeDaCena);
    }
}
