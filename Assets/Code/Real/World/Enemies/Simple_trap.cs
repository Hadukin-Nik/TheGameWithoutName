using UnityEngine;
using static UnityEngine.Debug;
namespace Code.Real.World.Enemies
{
    public class Simple_trap : MonoBehaviour
    {
        [SerializeField] private float _damage;
        private void OnTriggerEnter2D(Collider2D other)
        {
            Log("Hey! This is a Trap!");
 
            if (other.gameObject.GetComponent(typeof(IDamage)) is IDamage victim )
            {
                Log("Hey! You must Die!");
            
                victim.Damage(_damage);
                Destroy(gameObject);
            }
        }
    }
}