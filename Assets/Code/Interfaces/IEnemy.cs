namespace Code.Real.World.Interfaces
{
    public interface IEnemy
    {
        void Create(float health, float damage, float speed, float maxCount);
        
        void Check();
        
    }
}