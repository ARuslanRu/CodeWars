namespace CodeWars.PatternCraftAdapter
{
    public class MarioAdapter : IUnit
    {
        public Mario _mario { get; set; }
        public MarioAdapter(Mario mario)
        {
            _mario = mario;
        }
        public void Attack(Target target)
        {
            target.Health -= _mario.jumpAttack();
        }
    }
}
