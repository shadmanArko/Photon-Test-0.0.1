using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Rooms
{
    public class CreateRoomMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField]private TMP_Text _roomName;
        
        private RoomsCanvases _roomsCanvases;

        public void FirstInitialize(RoomsCanvases canvases)
        {
            _roomsCanvases = canvases;
        }

        public void OnClick_CreateRoom()
        {
            if (!PhotonNetwork.IsConnected)
            {
                return;
            }
            
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Created Room Successfully.", this);
            _roomsCanvases.CurrentRoomCanvas.Show();
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log("Room creation failed" + message, this);
        }
    }
    
    
}
