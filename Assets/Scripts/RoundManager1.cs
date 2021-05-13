using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager1 : MonoBehaviour
{
    public GameObject WinnerUI;
    public GameObject LoserUI;

    void Start()
    {
        WinnerUI.SetActive(false);
        LoserUI.SetActive(false);


    }



    public void WinnerUi()
    {


        WinnerUI.SetActive(true);

    }

    public void LoserUi()
    {

        LoserUI.SetActive(true);

    }
}
