using UnityEngine;

namespace Code.Real.World.Enviroment
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BonusDataScriptableObject", order = 1)]
    public class BonusData : ScriptableObject
    {
        public float PositionScale;
        public enum BonusTypeEffect
        {
            Heal = 0,
            Damage = 1,
            SpeedIncrease = 2,
            SpeedDecrease = 3,
            ExperiencesPoints = 4
        }   
        
        
    }
}