using UnityEngine;

public class EnemyAlertedState : EnemyAbstractState
{
    public override void EnterState(EnemyAI enemy)
    {
    }

    public override void UpdateState(EnemyAI enemy)
    {
        enemy.transform.LookAt(enemy.player.transform);
        if (Vector3.Distance(enemy.player.transform.position, enemy.target.transform.position) > 25)
        {
            enemy.SwitchState(enemy.WardState);
        }
    }
}
