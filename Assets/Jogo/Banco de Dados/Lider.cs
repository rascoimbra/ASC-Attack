using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Lider : MonoBehaviour
{

    public Text lideres;
    public Text lideres2;
    private int pontos; //isso sao moedas
    private string imputUsuario = "";

    // Start is called before the first frame update
    void Start()
    {
        string nomeDoUsuario = PlayerPrefs.GetString("usuariosalvo");
        if (nomeDoUsuario == "")
        {
           imputUsuario = "Visitante";
        }
        else { imputUsuario = nomeDoUsuario; }

        pontos = PlayerPrefs.GetInt("granasalva");
        StartCoroutine(AtualizarMoedas(imputUsuario, pontos));
        //PlayerPrefs.SetInt("granasalva", pontos);
        //StartCoroutine(PegaDados());
        //PegaDados();
        
    }

   public IEnumerator PegaDados()
    {
        string url = "https://portal10.info/jogo-apk/lider.php";
        UnityWebRequest www;
        www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            lideres.text = "Erro de conexão" + www.error;
        }
        else
        {
            //  bancoDeDados.text = www.downloadHandler.text;
            string baixado = www.downloadHandler.text;
            // bancoDeDados.text = baixado.Split('|')[1];

            lideres.text = "1º " + baixado.Split('|')[1] + "\n\n" + "2º " + baixado.Split('|')[2] + "\n\n" + "3º " + baixado.Split('|')[3] + "\n\n";
            lideres2.text = "4º " + baixado.Split('|')[4] + "\n\n" + "5º " + baixado.Split('|')[5] + "\n\n" + "6º " + baixado.Split('|')[6] + "\n\n" + "7º " + baixado.Split('|')[7] + "\n\n" + "8º " + baixado.Split('|')[8] + "\n\n" + "9º " + baixado.Split('|')[9] + "\n\n" + "10º " + baixado.Split('|')[10];


        }
    }
  
    IEnumerator AtualizarMoedas(string usuario, int moedas)
    {
        string atualizarUrl = "https://portal10.info/jogo-apk/editar-moedas.php";
        WWWForm form = new WWWForm();
        form.AddField("usuariopost", usuario);
        form.AddField("moedas", moedas);

        WWW www = new WWW(atualizarUrl, form);
        yield return www;
        Debug.Log(www.text);
        StartCoroutine(PegaDados());
        // Debug.Log(imputUsuario);

    }

}
