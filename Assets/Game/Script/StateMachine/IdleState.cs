
using UnityEngine;

public class IdleState : IState
{
    float timer;
    float randomTime;
    public void OnEnter(BotController enemy)
    {
        enemy.StopMoving();
        timer = 0;
        randomTime = 2f;
    }

    public void OnExcute(BotController enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            enemy.ChangeState(new PatrolState());
        }

    }

    public void OnExit(BotController enemy)
    {

    }
}
