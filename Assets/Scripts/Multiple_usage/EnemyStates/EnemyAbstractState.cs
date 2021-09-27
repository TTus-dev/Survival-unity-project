using UnityEngine;

public abstract class EnemyAbstractState
{
    public abstract void EnterState(EnemyAI enemy);

    public abstract void UpdateState(EnemyAI enemy);
}
