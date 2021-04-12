using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Rooms
{
    public class PlayerListing : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public Player Player
        {
            get;
            private set;
        }
        
        public void SetPlayerInfo(Player player)
        {
            Player = player;
            _text.text = player.NickName;
        }
    }
    
    
}
