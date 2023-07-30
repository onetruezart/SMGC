using System;
using UnityEngine;

namespace Input.Core
{
    public abstract class InputSystem : MonoBehaviour, IInputProvider
    {
        private protected int _countOfPlayers;
        private protected int _currentCountOfPlayers;

        public static IInputProvider CurrentInputProvider { get; private set; }

        public void Initialize(int players)
        {
            if (players is < 1)
                throw new Exception($"Invalid number of players. Your count of players = {players}, min = 1");
            _countOfPlayers = players;
            _currentCountOfPlayers = _countOfPlayers;
            Initialize();

            CurrentInputProvider = this;
        }

        private protected abstract void Initialize();

        public abstract void DeactivatePlayer(int playerId);

        public virtual bool GetKey(int keyId, int playerId)
        {
            return false;
        }
        
        public virtual bool GetKeyDown(int keyId, int playerId)
        {
            return false;
        }
        
        public virtual bool GetKeyUp(int keyId, int playerId)
        {
            return false;
        }
        
        public virtual float GetAxis(int axisId, int playerId)
        {
            return 0f;
        }
        
    }
}