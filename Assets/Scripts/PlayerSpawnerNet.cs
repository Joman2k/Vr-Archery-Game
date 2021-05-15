using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSpawnerNet : MonoBehaviourPunCallbacks
{
    private GameObject PlayerSpawnPrefab;
    public Transform[] spawnLocation;
    public GameObject XRrig;

    public RoundManager1 roundManager;



    //we want to spawn a player when someone uses the Join room function
  public override void OnJoinedRoom()
    {
        //Get a random transform from the spawn location list
        Transform Spawn = spawnLocation[Random.Range(0, spawnLocation.Length)];

        XRrig.transform.SetPositionAndRotation(Spawn.position, Spawn.rotation);

        base.OnJoinedRoom();
        //spawn the player prefab using the random position that is listed below
        PlayerSpawnPrefab = PhotonNetwork.Instantiate("Network Player", Spawn.position, Spawn.rotation);
        roundManager.NetworkHead = PlayerSpawnPrefab.GetComponent<NetworkPlayerRefrence>().HeadChild;
    }

    //when a player leaves it will destroy the player spawn prefab
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(PlayerSpawnPrefab);
    }
}
