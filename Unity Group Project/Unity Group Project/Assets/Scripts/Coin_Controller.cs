using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin_Controller : MonoBehaviour {

    //Declarations
    private Game_Master gm;  
    private static int IDCounter = 0;
    public int coinID = -1;
    public static Dictionary<int, bool> coinCollectedDatabase;
    private GameObject coinUI;
    private TextMeshProUGUI coinText;
    public static int coinNumber;

  
    //Assign unique ID for coin
    private void Reset()
    {   
        coinID = IDCounter;
        IDCounter++;
    }

    void Awake()
    {     
        if (coinCollectedDatabase == null) coinCollectedDatabase = new Dictionary<int, bool>();   
    }
   
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        coinUI = GameObject.FindGameObjectWithTag("CoinNumber");

        if (coinUI!=null)
        {
            coinText = coinUI.GetComponent<TextMeshProUGUI>();
        }

        coinNumber = gm.coinCollected;
        coinText.text = coinNumber.ToString();
        //Check collected coin
        if (coinCollectedDatabase.ContainsKey(coinID))
        { 
            //Destroy already collected coin
            if (coinCollectedDatabase[coinID]) Destroy(gameObject); 
        }
        else
        {
            coinCollectedDatabase.Add(coinID, false);
        }
    }

    //Assign true to collected coin
    void Collected()
    {
        coinCollectedDatabase[coinID] = true;
        coinText.text = coinNumber.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Increase coin number in  UI
            coinNumber++;
            //Play coin Sound
            OtherSound_Controller.OtherSound("CoinSound");
            //Coin colleted
            Collected();
            //increase the coin number in gamemaster to save it upon death
            gm.coinCollected ++;
            Destroy(gameObject);

        }
    }
}




  
