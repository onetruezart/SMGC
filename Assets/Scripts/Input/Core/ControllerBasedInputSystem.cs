using System;
using System.Collections.Generic;
using Input.Core.ControllerCore;
using Input.InputSystems.ButtonBased;
using UnityEngine;

namespace Input.Core
{
    public class ControllerBasedInputSystem : InputSystem
    {
        [SerializeField]
        private List<Controller> _playerControllers;
        
        public override void DeactivatePlayer(int playerId)
        {
            if (!ValidatePlayerController(playerId)) return;

            _playerControllers[playerId].SetActive(false);
            _currentCountOfPlayers -= 1;
        }
        
        public override bool GetKey(int keyId, int playerId)
        {
            if (!ValidatePlayerController(playerId)) return false;

            return (_playerControllers[playerId] is IKeyGetter) && ((IKeyGetter)_playerControllers[playerId]).GetKey(keyId);
        }
        
        public override bool GetKeyDown(int keyId, int playerId)
        {
            if (!ValidatePlayerController(playerId)) return false;
            return (_playerControllers[playerId] is IKeyDownGetter) && ((IKeyDownGetter)_playerControllers[playerId]).GetKeyDown(keyId);
        }
        
        public override bool GetKeyUp(int keyId, int playerId)
        {
            if (!ValidatePlayerController(playerId)) return false;

            return (_playerControllers[playerId] is IKeyUpGetter) && ((IKeyUpGetter)_playerControllers[playerId]).GetKeyUp(keyId);
        }
        
        public override float GetAxis(int axisId, int playerId)
        {
            if (!ValidatePlayerController(playerId)) return 0;
            return (_playerControllers[playerId] is IAxisGetter) ? ((IAxisGetter)_playerControllers[playerId]).GetAxis(axisId) : 0f;
        }
        
        private protected override void Initialize()
        {
            if (_countOfPlayers > _playerControllers.Count)
                throw new Exception($"Invalid number of players. Your count of players = {_countOfPlayers}, max = {_playerControllers.Count}");

            for (int i = 0; i < _playerControllers.Count; i++)
            {
                _playerControllers[i].SetActive(i < _countOfPlayers);
            }
        }
        
        private bool ValidatePlayerController(int id)
        {
            return id < _playerControllers.Count && id >= 0 && _playerControllers[id].IsActive;
        }
    }
}