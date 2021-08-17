using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI
{
    public class CharecterSelectionVisual : MonoBehaviour
    {
        [SerializeField] private Transform selectionAreaTransform;
        private Vector3 _startPosition; 
        private Vector3 _finalPosition;
        private CharacterSelectionController _controllerRts;
        
        
        public event Action<Collider2D[]> selectUnits;
        public event Action<Vector3, float> moveToUnit;
        public event Action deselectUnit;
        
        private void Start()
        {
             _controllerRts = new CharacterSelectionController(gameObject.GetComponent<CharecterSelectionVisual>());
             
             selectionAreaTransform.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                selectionAreaTransform.gameObject.SetActive(true);
                
                _startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (_controllerRts.canYouMoveUnits())
                {
                    deselectUnit.Invoke();
                }
             }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentMousePosion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 lowerLeft = new Vector3(Mathf.Min(_startPosition.x, currentMousePosion.x),
                    Mathf.Min(_startPosition.y, currentMousePosion.y));
                Vector3 upperRight = new Vector3(Mathf.Max(_startPosition.x, currentMousePosion.x),
                    Mathf.Max(_startPosition.y, currentMousePosion.y));

                selectionAreaTransform.position = lowerLeft;
                Debug.Log(upperRight + " " + lowerLeft);
                selectionAreaTransform.localScale = (upperRight - lowerLeft) * 100;

            }
            
            if (Input.GetMouseButtonUp(0))
            {
                selectionAreaTransform.gameObject.SetActive(false);

                _finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(_startPosition, _finalPosition);

                selectUnits.Invoke(collider2Ds);
            }

            if (Input.GetMouseButtonDown(1) && _controllerRts.canYouMoveUnits())
            {
                Vector3 goPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moveToUnit.Invoke(goPosition, Time.deltaTime);
            }
        }
        
        
    }
}