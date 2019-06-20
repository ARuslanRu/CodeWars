namespace CodeWars.PatternCraftAdapter
{
    public class Zergling : IUnit
    {
        public void Attack(Target target)
        {
            target.Health -= 5;
        }
    }
}
