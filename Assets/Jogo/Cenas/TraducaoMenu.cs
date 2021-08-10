using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TraducaoMenu : MonoBehaviour
{
   // public GameObject textosEmIngles;
   // public GameObject textosEmPortugues;
    public Text escolhaDeIdioma; //Texto Texmesh Pro
    public Text reward;
    public Text descricao;
    public Text moedas; //Texto comum
    public Button botaoPortugues;
    public Button botaoIngles;

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
        string url = "https://www.google-analytics.com/collect?v=1&tid=UA-17753792-10&cid=5555&t=pageview&dp=%2FMenu-ASC-Attack";
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
        escolhaDeIdioma.text = "Escolha seu idioma:";
        reward.text = "Earn 5 coins: ";
        descricao.text = "Defend yourself from various enemies and face powerful villains with weapons, bombs and all your skill. Discover and have fun with this fun Free Game!";
        moedas.text = "Wallet: ";

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
