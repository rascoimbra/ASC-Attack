using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class TraducaoCompras : MonoBehaviour
{
    // public GameObject textosEmIngles;
    // public GameObject textosEmPortugues;
    public Text titulo; //Texto Texmesh Pro
    public Text reward;
    public Text descricao;
    public Text moedas; //Texto comum
    public Text opcoesDeCompra;
   // public Button botaoPortugues;
   // public Button botaoIngles;

    // Start is called before the first frame update
    void Start()
    {
        int idioma = PlayerPrefs.GetInt("idioma");
        if (idioma >= 2)
        {
            IdiomaIngles();
        }
        else
        {

        }
        string url = "https://www.google-analytics.com/collect?v=1&tid=UA-17753792-10&cid=5555&t=pageview&dp=%2FASC-Attack-Compras";
        WWW www = new WWW(url);
    }

    public void IdiomaPortugues()
    {
        PlayerPrefs.SetInt("idioma", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IdiomaIngles()
    {
        PlayerPrefs.SetInt("idioma", 2);
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Mudar os seguintes textos
        titulo.text = "Welcome to the ACS Attack I Market:";
        reward.text = "Earn 5 coins: ";
        descricao.text = "Here you can add more joy and fun to your game and at the same time collaborate with its updates.";
        moedas.text = "Wallet: ";
        opcoesDeCompra.text = "Purchase options";

    }


    // Update is called once per frame
    void Update()
    {

    }
}
