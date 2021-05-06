using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


//We use Puncallbacks we can find out if we have connected to the server
public class NetworkManagerScript : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ServerConnect();
    }


    //this will be ran whenever someone starts the program and will allow them to connect to a server
    void ServerConnect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Attempting connection...");
    }


    //when someone joins the room we use a override to see when someone joins
    public override void OnConnectedToMaster()
    {

        Debug.Log("Connected to the server!");
        base.OnConnectedToMaster();
        //Settings for server rooms
        RoomOptions roomSettings = new RoomOptions();
        //max amount of players
        roomSettings.MaxPlayers = 2;
        //Shows the room???
        roomSettings.IsVisible = true;
        //Lets the player join the room even after it is created
        roomSettings.IsOpen = true;
        //Parameters to create or join a room
        PhotonNetwork.JoinOrCreateRoom("First Room", roomSettings, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room!");

        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player joined room");

        base.OnPlayerEnteredRoom(newPlayer);
    }
}
