using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player, target;

    public Quaternion originalrot;

    public EnemyAbstractState current_state;
    public EnemyWardState WardState = new EnemyWardState();
    public EnemyAlertedState AlertedState = new EnemyAlertedState();
    public EnemyChaseState ChaseState = new EnemyChaseState();
    public EnemyAttackState AttackState = new EnemyAttackState();
    public EnemyGetBackState GetBackState = new EnemyGetBackState();

    private void Start()
    {
        originalrot = transform.rotation;
        current_state = WardState;
        current_state.EnterState(this);
    }

    void Update()
    {
        current_state.UpdateState(this);
    }

    public void SwitchState(EnemyAbstractState newState)
    {
        current_state = newState;
        current_state.EnterState(this);
    }
}
