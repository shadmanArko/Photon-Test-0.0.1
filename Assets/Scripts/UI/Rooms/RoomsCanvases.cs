using System;
using UnityEngine;

namespace UI.Rooms
{
    public class RoomsCanvases : MonoBehaviour
    {
        
        [SerializeField] private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas;
        
        public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas
        {
            get { return _createOrJoinRoomCanvas; }
        }

        [SerializeField]private CurrentRoomCanvas _currentRoomCanvas;

        public CurrentRoomCanvas CurrentRoomCanvas
        {
            get { return _currentRoomCanvas; }
        }

        private void Awake()
        {
            FirstInitialize();
        }

        private void FirstInitialize()
        {
            CreateOrJoinRoomCanvas.FirstInitialize(this);
            CurrentRoomCanvas.FirstInitialize(this);
        }
    }
}