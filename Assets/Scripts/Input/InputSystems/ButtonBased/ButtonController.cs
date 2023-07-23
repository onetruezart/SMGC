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

        private bool _isDownThisFrame = false;
        private bool _isUpThisFrame = false;
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
            return _isDownThisFrame;
        }

        public bool GetKeyUp(int keyID)
        {
            return _isUpThisFrame;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDown = true;
            _isDownThisFrame = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDown = false;
            _isUpThisFrame = true;
        }

        private void LateUpdate()
        {
            _isDownThisFrame = false;
            _isUpThisFrame = false;
        }
    }
}