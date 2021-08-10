using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour {

	public Text healthText, damageText, fireRateText, bulletsText, reloadTimeText, upgradeCostText;

	GameManager gameManager;
	Player player;

	// Use this for initialization
	void Start () {

		gameManager = GameManager.gameManager;
		player = FindObjectOfType<Player>();
		UpdateUI();

	}
	
	void UpdateUI()
	{ // Escreve os valores e textos na tela
		healthText.text = "Max. Vida: " + gameManager.health;
		damageText.text = "Seu dano: " + gameManager.damage;
		fireRateText.text = "Tempo de tiro: " + gameManager.fireRate;
		bulletsText.text = "Munições: " + gameManager.bullets;
		reloadTimeText.text = "Temp. de Recarga: " + gameManager.reloadTime;
		upgradeCostText.text = "Custo de moedas por Upgrade: " + gameManager.upgradeCost;
	}

	public void SetHealth()
	{ //Botão + vida------------------------  
		if (gameManager.coins >= gameManager.upgradeCost) // Se suas moedas são maior ou igual ao custo do upgrade
		{ 
			gameManager.health++; //almenta a vida em 1
			FindObjectOfType<UIManager>().UpdateHealthBar(); // atualiza a barra de vida
			player.SetPlayerStatus(); //atualiza os status do player
			SetCoins(gameManager.upgradeCost); // atualiza o número de moedas que o player tem
			gameManager.upgradeCost += (gameManager.upgradeCost / 5); //Aumenta o custo do upgrade em 20%
			UpdateUI();
		}
        else
        {
		//	upgradeCostText.text = "VOCÊ NÃO TEM " + gameManager.upgradeCost +" MOEDAS!";
		}
	}

	public void SetDamage()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.damage++;
			
			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetFireRate()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.fireRate -= 0.1f;

			if(gameManager.fireRate <= 0)
			{
				gameManager.fireRate = 0;
			}

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetBullets()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.bullets++;

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	public void SetReloadTime()
	{
		if (gameManager.coins >= gameManager.upgradeCost)
		{
			gameManager.reloadTime -= 0.1f;

			if (gameManager.reloadTime <= 0)
			{
				gameManager.reloadTime = 0;
			}

			player.SetPlayerStatus();
			SetCoins(gameManager.upgradeCost);
			gameManager.upgradeCost += (gameManager.upgradeCost / 5);
			UpdateUI();
		}
	}

	void SetCoins(int coin) //atualiza o valor de moedas
	{
		gameManager.coins -= coin;
		FindObjectOfType<UIManager>().UpdateCoins();
	}
}
