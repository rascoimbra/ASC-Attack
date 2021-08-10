using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncluirAnuncios : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonetizationManager.Instance.ShowBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarInterstitial()
    {
        // FindObjectOfType<MonetizationManager>().ShowInterstitial(); //Mostrar banner ou videos ENTRE AS CENAS
        MonetizationManager.Instance.ShowInterstitial();
    }
    public void MostrarRewarded()
    {
       // FindObjectOfType<MonetizationManager>().ShowRewarded(); //Mostrar vídeos longos Ganhar moedas
        MonetizationManager.Instance.ShowRewarded();
    }
}
