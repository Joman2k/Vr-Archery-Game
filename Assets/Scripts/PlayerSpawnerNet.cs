using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSpawnerNet : MonoBehaviourPunCallbacks
{
    private GameObject PlayerSpawnPrefab;
    public Transform[] spawnLocationP1;
    public Transform[] spawnLocationP2;



    //we want to spawn a player when someone uses the Join room function
  public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PlayerSpawnPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);

        //Choose random spawn

        //if there is already a player spawn on the player 2 list
        //if()
    //    {
            


       // }
    }

    //when a player leaves it will destroy the player spawn prefab
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(PlayerSpawnPrefab);
    }
}
