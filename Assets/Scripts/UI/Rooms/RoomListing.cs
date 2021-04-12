using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Rooms
{
    public class RoomListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
      
        public RoomInfo RoomInfo { get; private set; }
        
        public void SetRoomInfo(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
        }

        public void OnClick_Button()
        {
            PhotonNetwork.JoinRoom(RoomInfo.Name);
        }
    }
    
    
}
 