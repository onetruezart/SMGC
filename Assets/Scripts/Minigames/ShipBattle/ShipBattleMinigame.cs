using System.Collections.Generic;
using Minigames.Core;
using UnityEngine;

namespace Minigames.ShipBattle
{
    public class ShipBattleMinigame : Minigame
    {
        [Tooltip("Item id = player id")]
        [SerializeField] private List<Ship> _ships;

        private List<int> _eliminationOrder = new List<int>();
        private protected override void OnStart()
        {
            for (int i = 0; i < _countOfPlayers; i++)
            {
                _ships[i].Initialize(i);
                _ships[i].OnDie += OnShipDie;
            }
            
            for (int i = _countOfPlayers; i < _ships.Count; )
            {
                Destroy(_ships[i].gameObject);
                _ships.RemoveAt(i);
            }
        }

        private protected override void OnUpdate()
        {
            foreach (var ship in _ships)
            {
                ship.OnUpdate();
            }
        }

        private protected override bool IsGameEnd()
        {
            return _ships.Count <= 1;
        }

        private void OnShipDie(int id)
        {
            _eliminationOrder.Add(id);
            _ships[id].OnDie -= OnShipDie;
            _ships.RemoveAt(id);
        }

        private protected override List<int> GetScore()
        {
            return null;
        }
    }
}