using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoundManager1 : MonoBehaviour
{
    public static RoundManager1 instance;
    public GameObject WinnerUI;
    public GameObject LoserUI;

    public GameObject PlayerHead;
    public GameObject NetworkHead;

    public Arrow ArrowScript;

   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
           
    void Start()
    {
        WinnerUI.SetActive(false);
        LoserUI.SetActive(false);
        

        
    }

    public void EndGame()
    {
        Debug.Log("Game has ended");
        // If either head explodes call this function
        if(PlayerHead == null && NetworkHead != null)
        {
            Debug.Log("You win!");

            WinnerUI.SetActive(true);

        }
        // This script will then check both player see if they have their head and assigns them the correct winner/loers UI

        if (PlayerHead != null && PlayerHead.name == "LocalHead")
        {
            Debug.Log("You lost");
            LoserUI.SetActive(true);
        }

    }

    
}
