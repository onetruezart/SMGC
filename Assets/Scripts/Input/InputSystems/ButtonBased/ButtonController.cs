using System;
using Input.Core.ControllerCore;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Input.InputSystems.ButtonBased
{
    public class ButtonController : Controller, IKeyGetter, IKeyDownGetter, IKeyUpGetter, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Button _button;

        private bool _isDownLastFrame = false;
        private bool _isDown = false;

        public override void Deactivate()
        {
            _button.interactable = false;
        }

        public override void Activate()
        {
            _button.interactable = true;
        }

        public bool GetKey(int keyID)
        {
            return _isDown;
        }

        public bool GetKeyDown(int keyID)
        {
            return _isDown && !_isDownLastFrame;
        }

        public bool GetKeyUp(int keyID)
        {
            return _isDownLastFrame && !_isDown;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isDown)
            {
                _isDownLastFrame = true;
            }
            else
            {
                _isDown = true;
                _isDownLastFrame = false;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isDown)
            {
                _isDownLastFrame = false;
            }
            else
            {
                _isDown = false;
                _isDownLastFrame = true;
            }
        }

        // private void LateUpdate()
        // {
        //     _isDownLastFrame = _isDown;
        // }
    }
}