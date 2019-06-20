namespace CodeWars.PatternCraftAdapter
{
    public class Marine : IUnit
    {
        public void Attack(Target target)
        {
            target.Health -= 6;
        }
    }
}
