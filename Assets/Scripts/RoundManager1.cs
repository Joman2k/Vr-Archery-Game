using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoundManager1 : MonoBehaviourPunCallbacks
{
    public static RoundManager1 instance;
    public GameObject WinnerUI;
    public GameObject LoserUI;

    public GameObject PlayerHead;
    public GameObject NetworkHead;

    public string collided;

    public List<NetworkPlayer> netPlayers;


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

    public void EndGame(NetworkPlayer winner)
    {
        //Checking for each player, I increases with each pass
        for (int i = 0; i < netPlayers.Count; i++)
        {
            if (netPlayers[i] == winner)
            {
                WinnerUI.SetActive(true);
            }
            else
            {
                LoserUI.SetActive(false);
            }
        }

        StartCoroutine(RestartGame());

        Debug.Log("Game has ended");
        // If either head explodes call this function
        //If the collided object has the same name as the varable then make it null
        if(PlayerHead != null && collided == PlayerHead.name)
        {
            PlayerHead = null;

        }
        //If the collided object has the same name as the varable then make it null
        if (NetworkHead != null && collided == NetworkHead.name)
        {
            NetworkHead = null;

        }
        if(PlayerHead == null)
        {
            Debug.Log("PLayers head destroyed");


        }
        if (NetworkHead == null)
        {
            Debug.Log("Network head is destoryed");

        }
        if(PlayerHead != null && NetworkHead == null)
        {
            Debug.Log("You win!");

            WinnerUI.SetActive(true);

        }
        // This script will then check both player see if they have their head and assigns them the correct winner/loers UI

        if (PlayerHead == null && NetworkHead != null)
        {
            Debug.Log("You lost");
            LoserUI.SetActive(true);
        }

    }

    IEnumerator RestartGame()
    {
        //wait 10 seconds after the game has ended
        yield return new WaitForSeconds(10);
        //Get the current scenes name
        Scene scene = SceneManager.GetActiveScene();
        //Load the current scene from its name 
        SceneManager.LoadScene(scene.name);

        //obsolete
        // Application.LoadLevel(Application.loadedLevel);
        // Put scene load here
    }


}
