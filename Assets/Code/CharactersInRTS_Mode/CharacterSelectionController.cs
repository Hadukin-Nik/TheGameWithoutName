using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI
{
    public class CharacterSelectionController
    {
        private List<CharacterController> _units;
        private CharecterSelectionVisual _charecterSelectionVisual;

        public event Action<bool> makeVisible;
        public CharacterSelectionController(CharecterSelectionVisual visual)
        {
            _charecterSelectionVisual = visual;
            
            
            _charecterSelectionVisual.deselectUnit += DeselectUnits;
            _charecterSelectionVisual.selectUnits += SelectUnits;

            _units = new List<CharacterController>();
        }

        public bool canYouMoveUnits()
        {
            return _units.Count > 0;
        }
        
        private void DeselectUnits() 
        {
            makeVisible.Invoke(false);

            foreach (var unit in _units)
            {
                _charecterSelectionVisual.moveToUnit -= unit._moveTo;
                makeVisible -= unit._changeSelectColor;
            }
            
            _units.Clear();
        }

        private void SelectUnits(Collider2D[] collidersSelected)
        {

            foreach (var collider in collidersSelected)
            {
                CharacterController unit = collider.GetComponent<CharacterVisual>()._characterControl;
                

                if (unit != null)
                {
                    _charecterSelectionVisual.moveToUnit += unit._moveTo;
                    makeVisible += unit._changeSelectColor;
                    
                    _units.Add(unit);
                }
            }
            
            makeVisible?.Invoke(true);
        }
    }
}