using UnityEngine;

namespace UI.Rooms
{
    public class CurrentRoomCanvas : MonoBehaviour
    {
        [SerializeField] private PlayerListingMenu _playerListingMenu;
        [SerializeField] private LeaveRoomMenu _leaveRoomMenu;
        public LeaveRoomMenu LeaveRoomMenu => _leaveRoomMenu;

        private RoomsCanvases _roomsCanvases;

        public void FirstInitialize(RoomsCanvases canvases)
        {
            _roomsCanvases = canvases;
            _playerListingMenu.FirstInitialize(canvases);
            _leaveRoomMenu.FirstInitialize(canvases);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
