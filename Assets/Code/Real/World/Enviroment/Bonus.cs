using UnityEngine;

namespace Code.Real.World.Enviroment
{
    public class Bonus : MonoBehaviour
    {
        [Header("Static Data")] [SerializeField]
        private BonusData _bonus;

        [Header("Customizable settings")] [SerializeField]
        private BonusData.BonusTypeEffect _typeEffect;
        [Header("Customizable settings")] [SerializeField]
        private float _count;
        
        
    }
}