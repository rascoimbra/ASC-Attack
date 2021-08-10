using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class TraducaoFinal : MonoBehaviour
{
    // public GameObject textosEmIngles;
    // public GameObject textosEmPortugues;
    public Text titulo; //Texto Texmesh Pro
    public Text fases;
    public Text descricao;
    public Text descricaoDoacao;
    public Text tituloDoacao; //Texto comum
    public Text botaoDoacao;
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
        string url = "https://www.google-analytics.com/collect?v=1&tid=UA-17753792-10&cid=5555&t=pageview&dp=%2FASC-Attack-FINAL";
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
        titulo.text = "Thanks for playing this little version.";
        fases.text = "ALL PHASES";
        descricao.text = "DON'T BE SAD, if all goes well, an update will come out tomorrow with new levels.";
        tituloDoacao.text = "Want to help the developer?";
        botaoDoacao.text = "Donate";
        descricaoDoacao.text = "You can donate a few cents by clicking on the button below:";

    }


    // Update is called once per frame
    void Update()
    {

    }
}
