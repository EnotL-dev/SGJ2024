namespace BattleSystem
{
    public class Attack : State
    {
        private AttackType _attackType;
        
        public Attack(StateBehaviour switcher, AttackType attackType) : base(switcher)
        {
            _attackType = attackType;
        }

        public override void StartState()
        {
            base.StartState();
            _attackType.DoAttack();
        }

     
    }
}