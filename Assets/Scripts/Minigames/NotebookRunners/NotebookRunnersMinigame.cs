using System.Collections.Generic;
using Minigames.Core;
using UnityEngine;

namespace Minigames.NotebookRunners
{
    public class NotebookRunnersMinigame : Minigame
    {
        [SerializeField] private List<Runner> _runners;

        private List<Runner> _inGameRunners = new List<Runner>();

        private int[] _eliminationOrder;
        private int _endedRunnersCount;
        public static Runner LeadingRunner { get; private set; } 
        
        private protected override void OnStart()
        {
            for (int i = 0; i < _countOfPlayers; i++)
            {
                _runners[i].Initialize(i);
                _runners[i].OnDie += OnRunnerDie;
                _runners[i].OnFinish += OnRunnerFinish;
                _inGameRunners.Add(_runners[i]);
            }
            
            for (int i = _countOfPlayers; i < _runners.Count; )
            {
                Destroy(_runners[i].gameObject);
                _runners.RemoveAt(i);
            }

            _eliminationOrder = new int[_inGameRunners.Count];
            LeadingRunner = _runners[0];
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

            LeadingRunner = _inGameRunners[iMax];

        }

        private protected override bool IsGameEnd()
        {
            return _inGameRunners.Count <= 1;
        }

        private void OnRunnerDie(int id)
        {
            _eliminationOrder[_endedRunnersCount] = id;
            _endedRunnersCount++;
            _inputSystem.DeactivatePlayer(id);
            _runners[id].OnDie -= OnRunnerDie;
            _inGameRunners.Remove(_runners[id]);
        }
        
        private void OnRunnerFinish(int id)
        {
            _eliminationOrder[^(_endedRunnersCount+1)] = id;
            _endedRunnersCount++;
            _inputSystem.DeactivatePlayer(id);
            _runners[id].OnFinish -= OnRunnerFinish;
            _inGameRunners.Remove(_runners[id]);
        }
        
        private protected override int[] GetScore()
        {
            _eliminationOrder[^1] = LeadingRunner.GetPlayerId();

            int[] scores = new int[_runners.Count];
            
            //scores[0] - 0 id player score, score[1] - 1 id player score etc.
            for (int i = 0; i < _eliminationOrder.Length; i++)
            {
                scores[_eliminationOrder[i]] = i+(4-_runners.Count);
            }
            
            return scores;
        }
    }
}