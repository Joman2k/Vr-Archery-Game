using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawnerNet : MonoBehaviourPunCallbacks
{
    private GameObject PlayerSpawnPrefab;

    //we want to spawn a player when someone uses the Join room function
  public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PlayerSpawnPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    //when a player leaves it will destroy the player spawn prefab
    public override void OnLeftRoom()
    {

        base.OnLeftRoom();
        PhotonNetwork.Destroy(PlayerSpawnPrefab);
    }
}
