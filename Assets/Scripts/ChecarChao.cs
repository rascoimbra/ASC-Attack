using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecarChao : MonoBehaviour
{
    Player player; // 1 - CRIA UMA VARIAVEL DO TIPO DO OUTRO SCRIPT
  //  Player player; //variavel com o mesmo nome do script no player
    // Start is called before the first frame update
    void Start() 
    {
        // player = gameObject.transform.parent.gameObject.GetComponent<Player>(); // pega o script Player que está no player.
        //  player = gameObject.GetComponent<Player>();
        

    }

    private void OnCollisionEnter2D(Collision2D collisor)
    {
       
        if (collisor.gameObject.layer == 9)
        {
            player = FindObjectOfType<Player>(); // 2 - ATRIBUI O OUTRO SCRIPT A VARIAVEL CRIADA
            player.onGround = true;
            //Debug.Log("No chao");
        }
    }
    private void OnCollisionExit2D(Collision2D collisor)
    {
        if (collisor.gameObject.layer == 9)
        {
            player = FindObjectOfType<Player>(); // 2 - ATRIBUI O OUTRO SCRIPT A VARIAVEL CRIADA
            player.onGround = false;
            //Debug.Log("Pulando");
        }
    }
}
