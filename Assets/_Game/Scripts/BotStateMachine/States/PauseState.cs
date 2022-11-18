using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState<Character>
{
    public void OnEnter(Character character)
    {
    }

    public void OnExecute(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);

        if(GameManager.Ins.currentgameState != GameState.Pause)
        {
            character.ChangeState(character.idleState);
        }
    }

    public void OnExit(Character character)
    {

    }
}
