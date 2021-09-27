using UnityEngine;

public class EnemyWardState : EnemyAbstractState
{
    bool reset_once;

    public override void EnterState(EnemyAI enemy)
    {
        enemy.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public override void UpdateState(EnemyAI enemy)
    {
        if (Vector3.Distance(enemy.player.transform.position, enemy.target.transform.position) <= 25)
        {
            enemy.SwitchState(enemy.AlertedState);
        }
    }
}
