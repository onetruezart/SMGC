using System.Collections.Generic;
using Minigames.Core;
using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class NotebookRunnersMinigame : Minigame
    {
        [SerializeField] private List<Runner> _runners;

        private List<Runner> _inGameRunners = new List<Runner>();
        
        private List<int> _eliminationOrder = new List<int>();
        
        public static Runner _leadingRunner { get; private set; } 
        
        private protected override void OnStart()
        {
            for (int i = 0; i < _countOfPlayers; i++)
            {
                _runners[i].Initialize(i);
                _runners[i].OnDie += OnRunnerDie;
                _inGameRunners.Add(_runners[i]);
            }
            
            for (int i = _countOfPlayers; i < _runners.Count; )
            {
                Destroy(_runners[i].gameObject);
                _runners.RemoveAt(i);
            }

            _leadingRunner = _runners[0];
        }

        private protected override void OnUpdate()
        {
            int iMax = 0;
            float xMax = float.MinValue;
            
            for (int i = 0; i<_inGameRunners.Count; i++)
            {
                _inGameRunners[i].OnUpdate();
                if (_inGameRunners[i].transform.position.x > xMax)
                {
                    xMax = _inGameRunners[i].transform.position.x;
                    iMax = i;
                }
            }

            _leadingRunner = _inGameRunners[iMax];

        }

        private protected override bool IsGameEnd()
        {
            return _inGameRunners.Count <= 1;
        }

        private void OnRunnerDie(int id)
        {
            _eliminationOrder.Add(id);
            _inputSystem.DeactivatePlayer(id);
            _runners[id].OnDie -= OnRunnerDie;
            _inGameRunners.Remove(_runners[id]);
        }
 
        private protected override int[] GetScore()
        {
            _eliminationOrder.Add(_leadingRunner.GetPlayerId());
            int[] scores = new int[_runners.Count];
            
            for (int i = 0; i < _eliminationOrder.Count; i++)
            {
                scores[_eliminationOrder[i]] = i;
            }
            
            return scores;
        }
    }
}