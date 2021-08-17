using Code.Real.World.Interfaces;
using UnityEngine;

namespace Code.Real.World.Enemies
{
    public sealed class TinySlime
{
    private GameObject _gameObject;
    private GameObject _parentObject;
    private Rigidbody2D _rigidbody2D;
    
    private float _speed;
    private float _maxDist;

    private Vector3 _lastDirection;
    public GameObject SlimeObject
    {
        get
        {
            return _gameObject;
        }
    }

    enum circlePhase
    {
        First = -1,
        Second = 1
    }

    private circlePhase a = circlePhase.First;
    public TinySlime(float maxDist, float speed, GameObject gameObject, GameObject parentObject)
    {
        _speed = speed;
        _gameObject = gameObject;
        _parentObject = parentObject;
        _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
        Vector2 parentObjectPosition = parentObject.transform.position;
        gameObject.transform.position = new Vector2(Random.Range(parentObjectPosition.x - maxDist, parentObjectPosition.x - 0.1f), 
            Random.Range(parentObjectPosition.y - maxDist, parentObjectPosition.y - 0.1f));
        

        _lastDirection.x = 1;
        _lastDirection.y = 1;

    }
    
    public void Check()
    {
        Vector2 moveDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        _gameObject.transform.LookAt(_parentObject.transform);

        if (_lastDirection.x > 0 && _gameObject.transform.up.x < 0 || _lastDirection.x < 0 && _gameObject.transform.up.x > 0)
        {
            if (a == circlePhase.First)
            {
                _speed *= -1;
                a = circlePhase.Second;
            }
            else
            {
                a = circlePhase.First;
            }

            if (_gameObject.transform.up.x < 0)
            {
                _lastDirection.x = -1;
            }
            else
            {
                _lastDirection.x = 1;
            }
        }
        
        _rigidbody2D.velocity = (_gameObject.transform.up * _speed);
        
        _gameObject.transform.eulerAngles = new Vector3(0f, 0f, _gameObject.transform.eulerAngles.z);

    }

    void Effect(GameObject Player)
    {
        int effect = Random.Range(1, 3);
        switch (effect)
        {
            case 1:
                var victim = Player.GetComponent(typeof(IDamage)) as IDamage;
                if (victim != null )
                {
                    victim.Damage(Random.Range(1, 5));
                }
                break;
            case 2:
                var victim1 = Player.GetComponent(typeof(ISpeed)) as ISpeed;
                if (victim1 != null )
                {
                    victim1.Speed(Random.Range(1, 5));
                }
                break;
        }
    }
}


}