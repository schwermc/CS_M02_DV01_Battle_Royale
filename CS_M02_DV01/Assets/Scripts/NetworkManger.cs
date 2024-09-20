using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManger : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;

    // instance
    public static NetworkManger instance;

    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We've connected to the master server!");
        PhotonNetwork.JoinLobby();
    }

    // attempts to create a room
    public void CreateRoom (string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(roomName, options);
    }

    // attempts to join a room
    public void JoinRoom (string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void changeScene (string scenename)
    {
        PhotonNetwork.LoadLevel(scenename);
    }
}
