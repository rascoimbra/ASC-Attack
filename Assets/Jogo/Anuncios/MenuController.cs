using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameManager gameManager; //Pega o gameManager e coloca na variável gameManager
    public Button interstitialButton;
    public Button rewardedButton;
    public Text coinsText;


    public GameObject removeAdsButton;

    void Start()
    {
        gameManager = GameManager.gameManager; //chama a variavel gameManager
        int moedas = gameManager.coins;
      //  int missao = PlayerPrefs.GetInt("missaosalva");
        if (moedas < 10)
        {
            rewardedButton.gameObject.SetActive(true);
        }
        else { rewardedButton.gameObject.SetActive(false); }


        MonetizationManager.Instance.OnPurchased += MonetizationManager_OnPurchased;
        MonetizationManager.Instance.OnCoinsChanged += MonetizationManager_OnCoinsChanged;
        MonetizationManager_OnPurchased(null);
        MonetizationManager_OnCoinsChanged(gameManager.coins); //atualizar o text
    }

    private void OnDestroy() // ATENÇÃO: SEMPRE QUE USAR UMA ACTION E +=, TEM QUE USAR O -= TAMBÉM.
    {
        if (MonetizationManager.Instance != null)
        {
            MonetizationManager.Instance.OnPurchased -= MonetizationManager_OnPurchased;
            MonetizationManager.Instance.OnCoinsChanged -= MonetizationManager_OnCoinsChanged;
        }
       
    }

    private void MonetizationManager_OnCoinsChanged(int coins)
    {
      coinsText.text = coins.ToString("N0");
    }

    private void MonetizationManager_OnPurchased(string productId)
    {
        bool purchaseRemoveAds = PlayerPrefs.GetInt("PURCHASED_REMOVEADS") == 1;
        removeAdsButton.SetActive(!purchaseRemoveAds);
    }

    public void OnInterstitialButtonClick()
    {
        MonetizationManager.Instance.ShowInterstitial();
    }
    public void OnRewardedButtonClick()
    {
        MonetizationManager.Instance.ShowRewarded();
    }

    public void SendNotification()
    {
      //  MonetizationManager.Instance.SendLocalNotification("Volte logo!", "Venha ver as novidades...");
    }
   
}
