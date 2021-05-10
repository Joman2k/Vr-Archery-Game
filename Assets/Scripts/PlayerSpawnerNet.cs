using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSpawnerNet : MonoBehaviourPunCallbacks
{
    private GameObject PlayerSpawnPrefab;
    public Transform[] spawnLocationP1;
    
    //we want to spawn a player when someone uses the Join room function
  public override void OnJoinedRoom()
    {
        //Get a random transform from the spawn location list
        Transform P1Spawn = spawnLocationP1[Random.Range(0, spawnLocationP1.Length)];

        

        base.OnJoinedRoom();
        //spawn the player prefab using the random position that is listed below
        PlayerSpawnPrefab = PhotonNetwork.Instantiate("Network Player", P1Spawn.position, P1Spawn.rotation);
    }

    //when a player leaves it will destroy the player spawn prefab
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(PlayerSpawnPrefab);
    }
}
