using StateMachine.CharacterController;
using StateMachine.CharacterMachine;
using StateMachine.CharacterState;

public class RunState : State
{
    public RunState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        character.animator.SetBool("isRunning", true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        // Implement logic for running state, e.g., checking for input to stop running
        // if (character.inputHandler.IsRunning() == false)
        // {
        //     stateMachine.ChangeState(character.idleState);
        // }
    }

    public override void Exit()
    {
        base.Exit();
        character.animator.SetBool("isRunning", false);
    }
}