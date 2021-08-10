using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class CadastroLoguin : MonoBehaviour
{
    public GameObject loginCanvas;
    public GameObject botaoCadastreSe;
    [SerializeField]
    private InputField campoUsuario;
    [SerializeField]
    private InputField campoSenha;
    [SerializeField]
    private InputField campoEmail;
    string imputJogo = "ASC Attack";
    public Text aviso;
    string imputUsuario;
    string imputSenha;
    string imputEmail;
    string nomeDoUsuario;
    public Text nome;


    // Start is called before the first frame update
    void Start()
    {
        nomeDoUsuario = PlayerPrefs.GetString("usuariosalvo");
       // Debug.Log(nomeDoUsuario);
        if (nomeDoUsuario == "")
        {
           // Debug.Log("nomeDoUsuario vazio");
            loginCanvas.gameObject.SetActive(true);
            botaoCadastreSe.gameObject.SetActive(true);
        }
        else 
        { 
            nome.text = "Olá " +nomeDoUsuario;
            loginCanvas.gameObject.SetActive(false);
            botaoCadastreSe.gameObject.SetActive(false);


        }
    }

    public void Visitante()
    {
        loginCanvas.gameObject.SetActive(false);
        nome.text = "";
        botaoCadastreSe.gameObject.SetActive(true);
}
public void Entrar()
    {
        if (campoSenha.text == "")
        {
            aviso.text = "Por favor, preencha o campo SENHA";
        }
        else if (campoUsuario.text == "")
        {
            aviso.text = "Por favor, preencha o campo USUARIO";
        }
        else {
            imputSenha = campoSenha.text;
            imputUsuario = campoUsuario.text;
            imputEmail = campoSenha.text;
            StartCoroutine(LoginNoSite(imputUsuario, imputSenha));
        }
        
    }

    IEnumerator LoginNoSite(string usuario,  string senha)
    {
        string loginUrl = "https://portal10.info/jogo-apk/entrar3.php";
        WWWForm form = new WWWForm();
        form.AddField("imputUsuario", usuario);
        form.AddField("imputSenha", senha);
        WWW www = new WWW(loginUrl, form);
        yield return www;
        //Debug.Log(www.text);
        if(www.text == "entrou")
        {
            //Debug.Log("Tudo ok");
            nomeDoUsuario = imputUsuario;
            PlayerPrefs.SetString("usuariosalvo", nomeDoUsuario);
            nome.text = "Olá " + nomeDoUsuario;
            botaoCadastreSe.gameObject.SetActive(false);
            loginCanvas.gameObject.SetActive(false);
        }
        else { aviso.text = www.text; }
    }
    //---------------------------------------------------------------
    public void Cadastrar()
    {
        if (campoSenha.text == "")
        {
            aviso.text = "Por favor, preencha o campo SENHA";
        }
        else if (campoUsuario.text == "")
        {
            aviso.text = "Por favor, preencha o campo USUARIO";
        }
        else if (campoEmail.text == "")
        {
            aviso.text = "Por favor, preencha o seu EMAIL";
        }
        else
        {
            imputSenha = campoSenha.text;
            imputUsuario = campoUsuario.text;
            StartCoroutine(CriarUsuario(imputUsuario, imputSenha, imputJogo, imputEmail));
        }
    }
    IEnumerator CriarUsuario(string usuario, string senha, string jogo, string email)
    {
        string novoUsuarioUrl = "https://portal10.info/jogo-apk/inserir.php";
        WWWForm form = new WWWForm();
        form.AddField("usuariopost", usuario);
        form.AddField("senhapost", senha);
        form.AddField("emailpost", email);
        form.AddField("jogopost", jogo);

        WWW www = new WWW(novoUsuarioUrl, form);
        yield return www;
        if (www.text == "sucesso")
        {
            //Debug.Log("Tudo ok");
            nomeDoUsuario = imputUsuario;
            PlayerPrefs.SetString("usuariosalvo", nomeDoUsuario);
            nome.text = "Olá " + nomeDoUsuario;
            botaoCadastreSe.gameObject.SetActive(false);
            loginCanvas.gameObject.SetActive(false);
        }
        else { aviso.text = www.text; }
    }
}
