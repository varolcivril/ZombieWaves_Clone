using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    private Coroutine HomingCoroutine;
    public float yOffset = 1f;

    public override void Spawn(Vector3 Forward, int Damage, Transform Target)
    {
        this.Damage = Damage;
        this.Target = Target;

        if (HomingCoroutine != null)
        {
            StopCoroutine(HomingCoroutine);
        }

        HomingCoroutine = StartCoroutine(FindTarget());
    }

    private IEnumerator FindTarget()
    {
        Vector3 startPosition = transform.position;
        float time = 0;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, Target.position + new Vector3(0, yOffset, 0), time);
            transform.LookAt(Target.position + new Vector3(0, yOffset, 0));

            time += Time.deltaTime * MoveSpeed;

            yield return null;
        }
    }
}
