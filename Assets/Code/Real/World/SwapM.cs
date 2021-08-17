using UnityEngine;

namespace Code.Real.World
{
    public class SomeExamples
    {
        public void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        public void Example1<T, U>(T DoorWithBonus, GameObject b) where T : IDoor, IBonus
        {
            DoorWithBonus.OpenTheDoor();
            DoorWithBonus.DoSomeEffect(b);
        }

        public void ExampleDebug<T>(ref T someDebugItem, string textMessage)
        {
            Debug.Log(textMessage + " "  + someDebugItem);
        }
    }
}