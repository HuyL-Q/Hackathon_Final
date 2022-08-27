using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 targetPosition;
    private float damage;
    private Action<GameObject> action;

    public float Damage
    {
        set
        {
            damage = value;
        }
    }

    private AEnemy target;

    public AEnemy Target
    {
        set { target = value; }
    }

    private void Update()
    {
        //if (!target.isActiveAndEnabled)
        //{
        //    action(this);
        //    Target = null;
        //    return;
        //}
        //targetPosition = target.transform.position;

        //Vector3 moveDir = (targetPosition - transform.position).normalized;

        //float moveSpeed = 10f;

        //transform.position += moveDir * moveSpeed * Time.deltaTime;

        //float angle = GetAngleFromFloatVector(moveDir);
        //transform.eulerAngles = new Vector3(0, 0, angle);

        //float destroyDistance = 0.1f;
        //if (Vector3.Distance(transform.position, targetPosition) < destroyDistance)
        //{
        //    target.ReceiveDamage(damage);
        //    action(this);
        //}
    }
    float GetAngleFromFloatVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public void DisableAction(Action<GameObject> releaseAction)
    {
        action = releaseAction;
    }
}