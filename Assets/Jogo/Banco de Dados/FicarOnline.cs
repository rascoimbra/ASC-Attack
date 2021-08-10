using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FicarOnline : MonoBehaviour
{
    private string imputUsuario = "Visitante";
    private int imputonline = 1;
    private string nomeDoUsuario;
    bool isPaused = false;
    string loginUrl = "https://portal10.info/jogo-apk/ficaronline.php";

    // Start is called before the first frame update 
    void Start()
    {
        nomeDoUsuario = PlayerPrefs.GetString("usuariosalvo");
        if (nomeDoUsuario == "")
        {
            imputUsuario = "Visitante";
        }
        else { imputUsuario = nomeDoUsuario; }
        FicouOnline();
    }
    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
        FicouOnline();
    }

  /*  void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
        FicouOnline();
    }
 */   public void FicouOnline()
    {
        if (isPaused == true)
        {
          imputonline = 0;
        }
        else { imputonline = 1; }
        StartCoroutine(Online(imputUsuario, imputonline));
    }

    IEnumerator Online(string usuario, int online)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuariopost", usuario);
        form.AddField("onlinepost", online);

        WWW www = new WWW(loginUrl, form);
        yield return www;
      //  Debug.Log(www.text);
     //   Debug.Log(imputUsuario);

    }
}
