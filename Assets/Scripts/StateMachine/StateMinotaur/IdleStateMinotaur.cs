using StateMachine.StateMinotaur;

public class IdleStateMinotaur : MinotaurState
{
    public IdleStateMinotaur(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine)
        : base(minotaur, stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        minotaur.animator.SetTrigger("isAttack");
    }

    public override void LogicUpdate()
    {
       
    }

    public override void Exit()
    {
        base.Exit();
    }
}