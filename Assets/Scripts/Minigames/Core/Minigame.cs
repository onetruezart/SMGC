using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Input.Core;
using UnityEngine;

namespace Minigames.Core
{
    public abstract class Minigame : MonoBehaviour
    {
        [SerializeField] private protected int _countOfPlayers;
        [SerializeField] private InputSystem _inputSystem;
        
        private void Start()
        {
            //TODO: check for max player
            PlayMinigame(_countOfPlayers);
        }

        public async UniTask<List<int>> PlayMinigame(int players)
        {
            _inputSystem.Initialize(players);
            OnStart();
            while (!IsGameEnd())
            {
                await UniTask.Yield(PlayerLoopTiming.EarlyUpdate);
                OnUpdate();
            }
            Debug.Log("GameEnd!");
            return GetScore();
        }
        
        // public abstract void Stop();
        private protected abstract void OnStart();
        private protected abstract void OnUpdate();
        private protected abstract bool IsGameEnd();
        private protected abstract List<int> GetScore();
    }
}
