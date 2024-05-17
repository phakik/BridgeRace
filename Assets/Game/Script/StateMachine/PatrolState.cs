
using UnityEngine;

public class PatrolState : IState
{

    public void OnEnter(BotController enemy)
    {
        enemy.FindTarget();

    }
    public void OnExcute(BotController enemy)
    {
        if (enemy.Tartlist.Count != 0)
        {
            if (enemy.PickBrick.Count > 5)
            {
                enemy.ChangeState(new MoveToDesState());
            }
            else if (Vector3.Distance(enemy.transform.position, enemy.nextPos) < 0.5f)
            {
                enemy.FindTarget();
            }
        }
        else if (enemy.Tartlist.Count == 0)
        {
            enemy.ChangeState(new IdleState());
        }
    }
    public void OnExit(BotController enemy)
    {

    }
}

