using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDeFases : MonoBehaviour
{
  //  public GameObject cena1;
    public Button botaoDaFase1;
    public Button botaoDaFase2;
    private int nivel;
    public Text niveltexto;

    // Start is called before the first frame update
    void Start()
    {
        nivel = PlayerPrefs.GetInt("nivelsalvo");
        niveltexto.text = nivel.ToString();
        if (nivel >= 0) { botaoDaFase1.interactable = true; }
        else { botaoDaFase1.interactable = false; }

        if (nivel >= 2) { botaoDaFase2.interactable = true; }
        else { botaoDaFase2.interactable = false; }

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
