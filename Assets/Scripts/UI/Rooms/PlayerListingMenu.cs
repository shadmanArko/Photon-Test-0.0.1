using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace UI.Rooms
{
    public class PlayerListingMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PlayerListing _playerListing;
        [SerializeField] private Transform _content;
        [SerializeField] private TMP_Text _readyUpText;

        private List<PlayerListing> _listings = new List<PlayerListing>();
        private RoomsCanvases _roomsCanvases;
        private bool _ready;

       
        public override void OnEnable()
        {
            base.OnEnable();
        
            GetCurrentRoomPlayers();
            
            SetReadyUp(false);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            for (int i = 0; i < _listings.Count; i++)
            {
                Destroy(_listings[i].gameObject);
                _listings.Clear();
            }
        }

        public void FirstInitialize(RoomsCanvases canvases)
        {
            _roomsCanvases = canvases;
        }

        private void SetReadyUp(bool state)
        {
            _ready = state;

            _readyUpText.text = _ready ? "R" : "N";
        }
    
        private void GetCurrentRoomPlayers()
        {
            if (!PhotonNetwork.IsConnected)
            {
                return;
            }

            if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            {
                return;
            }
            foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerListing(playerInfo.Value);
            }
        }

        public void AddPlayerListing(Player player)
        {
            int index = _listings.FindIndex(x => Equals(x.Player, player));
            if (index != -1)
            {
                _listings[index].SetPlayerInfo(player);
            }
            else
            {
                PlayerListing listing = Instantiate(_playerListing, _content);
                if (listing != null)
                {
                    listing.SetPlayerInfo(player);
                    _listings.Add(listing);
                }
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerListing(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            int index = _listings.FindIndex(x => Equals(x.Player, otherPlayer));
            if (index != -1)
            {
                Destroy(_listings[index].gameObject);
                _listings.RemoveAt(index);
            }
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            _roomsCanvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
        }

        public void OnClick_StartGame()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                for (int i = 0; i < _listings.Count; i++)
                {
                    if (_listings[i].Player != PhotonNetwork.LocalPlayer)
                    {
                        if (!_listings[i].Ready)
                        {
                            return;
                        }
                    }
                }
                
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                PhotonNetwork.LoadLevel(1);    
            }
        }

        public void OnClick_ReadyUp()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                SetReadyUp(!_ready);
                base.photonView.RPC("RPC_ChangeReady", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
            }
        }

        [PunRPC]
        public void RPC_ChangeReady(bool ready, Player player)
        {
            int index = _listings.FindIndex(x => Equals(x.Player, player));
            if (index != -1)
            {
                _listings[index].Ready = ready;
            }
        }
    
    }
}
