using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDesState : IState
{
    public void OnEnter(BotController enemy)
    {
        enemy.agent.SetDestination(enemy.goalDes.transform.position);
    }
    public void OnExcute(BotController enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.goalDes.transform.position) < 1f)
        {
            enemy.StopMoving();
            return;

        }
        else if (enemy.OnStair == true && enemy.CanMove == false)
        {

            enemy.SetRB(Vector3.zero);
            enemy.ChangeState(new PatrolState());
        }

    }
    public void OnExit(BotController enemy)
    {
    }
}
