using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variaveis : MonoBehaviour
{
    private int nivel;
    private int moedas;
    public Text niveltexto;
    // Start is called before the first frame update
    void Start()
    {
        nivel = PlayerPrefs.GetInt("nivelsalvo");
        moedas = PlayerPrefs.GetInt("granasalva");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GanharNivel()
    {
        nivel = PlayerPrefs.GetInt("nivelsalvo");
        nivel += 1;
        niveltexto.text = nivel.ToString();
        PlayerPrefs.SetInt("nivelsalvo", nivel);
            //   PlayerPrefs.Save(); //Salva o player prefs na hora
    }
    public void PerderNivel()
    {
        nivel = PlayerPrefs.GetInt("nivelsalvo");
        nivel -= 1;
        niveltexto.text = nivel.ToString();
        PlayerPrefs.SetInt("nivelsalvo", nivel);
        //   PlayerPrefs.Save(); //Salva o player prefs na hora
    }
}
