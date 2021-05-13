using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headexplosion : MonoBehaviour
{
    public GameObject HeadshatteredPrefab;

    //public RoundManager1 Loser;

    //When head is hit with arrow , explode into the shattered prefab

    public void Start()
    {
        //Loser = GameObject.Find("RoundManager").GetComponent<RoundManager1>();

    }
    public void ExplodeHead()
    {
        GameObject explodedhead = Instantiate(HeadshatteredPrefab);
        explodedhead.transform.position = transform.position;
       // Loser.LoserUi();
        Debug.Log("Head hit");
        Destroy(gameObject);
  
    }
}
