using System;
using UnityEngine;


namespace Code.UI
{
    public class CharacterController
    {
        private CharacterVisual _characterVisualObject;
        public Action<bool> _changeSelectColor { get; private set; }
        public Action<Vector3, float> _moveTo{ get; private set; }
        public CharacterController(Action<bool> changeSelectColor, Action <Vector3, float> moveTo)
        {
            _changeSelectColor = changeSelectColor;
            _moveTo = moveTo;
        }
    }
}