using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.Rooms
{
    public class RoomListingMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private RoomListing _roomListing;
        [SerializeField] private Transform _content;

        private List<RoomListing> _listings = new List<RoomListing>();
        private RoomsCanvases _roomsCanvases;

        public void FirstInitialize(RoomsCanvases canvases)
        {
            _roomsCanvases = canvases;
        }

        public override void OnJoinedRoom()
        {
            _roomsCanvases.CurrentRoomCanvas.Show();
            _content.DestroyChildren();
            _listings.Clear();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                if (info.RemovedFromList)
                {
                    int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                    if (index != -1)
                    {
                        Destroy(_listings[index].gameObject);
                        _listings.RemoveAt(index);
                    }
                }

                else
                {
                    int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);

                    if (index == -1)
                    {
                        RoomListing listing = Instantiate(_roomListing, _content);
                        if (listing != null)
                        {
                            listing.SetRoomInfo(info);
                            _listings.Add(listing);
                        }
                    }

                    else
                    {
                        
                    }
                   
                }
                
                
            }
        }
    }
}
