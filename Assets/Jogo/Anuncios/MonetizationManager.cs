using System.Collections;
using System.Collections.Generic;
using System; // Trabalhar com eventos e não com o Update
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Purchasing;
using UnityEngine.UI;
//using Unity.Notifications.Android;


public class MonetizationManager : MonoBehaviour, IUnityAdsListener
{
    GameManager gameManager; //Pega o gameManager e coloca na variável gameManager
    public event Action<string> OnPurchased; // Trabalhar com eventos e não com o Update
    public event Action<int> OnCoinsChanged;

    public GameObject meuBanner;
    public GameObject meuInterstition;
    public GameObject meuRewarded;
    public Button buttonClose;
    public Image closeImage;
    int timeout = 3;

    private static MonetizationManager _Instance;
    public static MonetizationManager Instance 
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<MonetizationManager>();

                if (_Instance == null)
                {
                    GameObject monetizationObject = Instantiate(Resources.Load<GameObject>("MonetizationManager"));
                    _Instance = monetizationObject.GetComponent<MonetizationManager>();
                }
            }
            
            return _Instance;
        }
    }

 //-------------------------------------------------------------
    void Start()
    {
        gameManager = GameManager.gameManager; //chama a variavel gameManager
        DontDestroyOnLoad(this);
        buttonClose.gameObject.SetActive(false);
        meuBanner.SetActive(false);
        meuInterstition.SetActive(false);
        meuRewarded.SetActive(false);
        //Caso seja necessario mostrar banners logo no start
        ShowBanner();

        string gameId = "";
#if UNITY_IOS
        gameId = "4163684";
#elif UNITY_ANDROID
        gameId = "4163685";
#endif
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, Debug.isDebugBuild); // Comentar para não vir anúncios da Unity--------------------

        //var channel = new AndroidNotificationChannel()
        //{
        //    Id = "channel_id",
        //    Name = "Default Channel",
        //    Importance = Importance.Default,
        //    Description = "Generic notifications",
        //};
        //AndroidNotificationCenter.RegisterNotificationChannel(channel);

    }
    //--------------------------------------------------------------
    private void Update()
    {
        if(closeImage.fillAmount < 1)
        {
            closeImage.fillAmount += Time.deltaTime / timeout;
        }
        else
        {
            buttonClose.interactable = true;
        }
    }
    //--------------------------------------------------------------
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    //--------------------------------------------------------------

    public void ShowInterstitial()
    {
        if (PlayerPrefs.GetInt("PURCHASED_REMOVEADS") == 1) return;

        HideBanner();
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            timeout = 3;
           buttonClose.gameObject.SetActive(true);
            buttonClose.interactable = false;
            closeImage.fillAmount = 0;
           meuInterstition.SetActive(true);
        }
       
    }
    //---------------------------------------------------------------
    public void ShowRewarded()
    {
        HideBanner();
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            timeout = 5;
            buttonClose.gameObject.SetActive(true);
            buttonClose.interactable = false;
            closeImage.fillAmount = 0;
            meuRewarded.SetActive(true);
            Invoke("RewardUser", timeout);
        }
    }
   
    //----------------------------------------------------
    public void ShowBanner()
    {
        if (PlayerPrefs.GetInt("PURCHASED_REMOVEADS") == 1) return;

        if (Advertisement.IsReady("Banner_Android")) 
        {
            meuBanner.SetActive(false);
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            meuBanner.SetActive(true);
            Advertisement.Banner.Hide();
        }
       
    }
    //---------------------------------------------------------------
    public void HideBanner()
    {
        meuBanner.SetActive(false);
        Advertisement.Banner.Hide();
    }
    //----------------------------------
    public void OnUnityAdsReady(string placementId)
    {
        //executa quando um placementid está pronto para ser mostrado na tela
        //Mostrar banner
        if (placementId.Equals("Banner_Android"))
        {
            ShowBanner();
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("UNITY ADS ERRO: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //executa quando um vídeo começa a ser mostrado na tela
    }
    //----------------------------------
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {         //executa quando a propaganda termina
        ShowBanner();
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            RewardUser();
        }
    }
    //----------------------------------
    public void RewardUser()
    {
        AddCoins(5);
    }
    //----------------------------------
    public void AddCoins(int coinsToAdd)
    {
        int coins = gameManager.coins;
        coins += coinsToAdd;
      //  PlayerPrefs.SetInt("granasalva", coins);
      //  PlayerPrefs.Save(); //Salva o player prefs na hora
        gameManager.coins += coinsToAdd;
        OnCoinsChanged?.Invoke(coins);
    }
    //----------------------------------
    public void OnPurchaseComplete(Product product) 
    {
        if (product.definition.id.Equals("coinspack1"))
        {
            AddCoins(50);
        }
        if (product.definition.id.Equals("removeads"))
        {
            PlayerPrefs.SetInt("PURCHASED_REMOVEADS", 1);
            PlayerPrefs.Save(); //Salva o player prefs na hora
            HideBanner();
        }
        // Trabalhar com eventos e não com o Update
        if (OnPurchased != null)
        {
            OnPurchased(product.definition.id);
        }
    }

    //public void SendLocalNotification (string title, string msg)
    //{
    //    var notification = new AndroidNotification();
    //    notification.Title = title;
    //    notification.Text = msg;
    //    notification.LargeIcon = "large_icon";
    //    notification.FireTime = System.DateTime.Now.AddSeconds(10);
    //   // notification.FireTime = System.DateTime.Now.AddMinutes(1);

    //    AndroidNotificationCenter.SendNotification(notification, "channel_id");
    //}
    
}
