using System;
using UnityEngine;

namespace Code.UI
{
    public class CharacterVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _selected;

        
        [SerializeField] private float health;
        [SerializeField] private float speed;

        private Rigidbody2D _rigidBody;
        
        public CharacterController _characterControl { get; private set; }
        public void Awake()
        {
            _characterControl = new CharacterController(MakeVisible, GoToThePosition);
            _selected.SetActive(false);

            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void GoToThePosition(Vector3 finalPosition, float deltaTime)
        {
            //ToHardToMakeMultipleMoveLogicForRTS_Game and that is why:

            Vector3 directionOfMovement = gameObject.transform.position - finalPosition;

            directionOfMovement = directionOfMovement.normalized;

            _rigidBody.velocity = directionOfMovement * speed * deltaTime;
        }

        private void MakeVisible(bool canYouSee)
        {
            _selected.SetActive(canYouSee);
        }
    }
}