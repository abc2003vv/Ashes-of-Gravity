using StateMachine.StateMinotaur;

public class RunStateMinotaur : MinotaurState
{
    public RunStateMinotaur(ControllStateMinotaur minotaur, MinotaurStateMachine stateMachine) 
        : base(minotaur, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        minotaur.animator.SetBool("isRunning", true);
    }

    public override void LogicUpdate()
    {
        // Logic for running state can be added here
    }

    public override void Exit()
    {
        base.Exit();
        minotaur.animator.SetBool("isRunning", false);
    }
}