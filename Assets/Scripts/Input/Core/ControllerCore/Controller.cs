using UnityEngine;

namespace Input.Core.ControllerCore
{
    public abstract class Controller : MonoBehaviour
    {
        public bool IsActive => _isActive;
        private protected bool _isActive = true;

        public void SetActive(bool isActive)
        {
            _isActive = isActive;

            if (isActive)
                Activate();
            else
                Deactivate();    
        }

        public abstract void Deactivate();
        public abstract void Activate();
    }
}