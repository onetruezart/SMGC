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
            _button.enabled = false;
        }

        public override void Activate()
        {
            _button.enabled = true;
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
            _isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDown = false;
        }

        private void LateUpdate()
        {
            _isDownLastFrame = _isDown;
        }
    }
}