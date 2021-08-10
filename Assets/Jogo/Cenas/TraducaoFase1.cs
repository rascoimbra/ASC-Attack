using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class TraducaoFase1 : MonoBehaviour
{
    // public GameObject textosEmIngles;
    // public GameObject textosEmPortugues;
   // public Text titulo; //Texto Texmesh Pro
  //  public Text reward;
    public TextMeshProUGUI descricao;
    public TextMeshProUGUI parabens;
    public TextMeshProUGUI vocePassou;
    public TextMeshProUGUI proximaFase;
    public TextMeshProUGUI voltar;
    public TextMeshProUGUI ajudar;
    //   public Text moedas; //Texto comum
    //   public Text opcoesDeCompra;
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
        string url = "https://www.google-analytics.com/collect?v=1&tid=UA-17753792-10&cid=5555&t=pageview&dp=%2FASCAttack-Fase1";
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
     //   titulo.text = "Welcome to the ACS Attack I Market:";
     //   reward.text = "Earn 5 coins: ";
        descricao.text = "You died... <br> :-( <br> Restarting in 5 seconds...";
        parabens.text = "Very Good!";
        vocePassou.text = "You have passed this stage. <br> Where do you want to go now?";
        proximaFase.text = "NEXT PHASE";
        voltar.text = "MAIN MENU";
        ajudar.text = "HELP THE DEVELOPER";
     //   moedas.text = "Wallet: ";
     //   opcoesDeCompra.text = "Purchase options";

    }


    // Update is called once per frame
    void Update()
    {

    }
}
