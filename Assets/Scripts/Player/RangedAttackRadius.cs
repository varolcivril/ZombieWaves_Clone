using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAttackRadius : AttackRadius
{
    public Bullet BulletPrefab;
    public Vector3 BulletspawnOffset = new Vector3(0, 1, 0);
    public LayerMask Mask;
    private ObjectPool BulletPool;
    [SerializeField] private float SpherecastRadius = 0.1f;
    private RaycastHit Hit;
    private IDamageable TargetDamageable;
    private Bullet Bullet;

    protected override void Awake()
    {
        base.Awake();

        BulletPool = ObjectPool.CreateInstance(BulletPrefab, Mathf.CeilToInt((1 / AttackDelay) * BulletPrefab.AutoDestroyTime));
    }

    protected override IEnumerator Attack()
    {
        WaitForSeconds Wait = new WaitForSeconds(AttackDelay);

        yield return Wait;

        while (Damageables.Count > 0)
        {
            for (int i = 0; i < Damageables.Count; i++)
            {
                if (HasLineOfSightTo(Damageables[i].GetTransform()))
                {
                    TargetDamageable = Damageables[i];
                    OnAttack?.Invoke(Damageables[i]);
                    break;
                }
            }

            if (TargetDamageable != null)
            {
                PoolableObject poolableObject = BulletPool.GetObject();
                if (poolableObject != null)
                {
                    Bullet = poolableObject.GetComponent<Bullet>();

                    Bullet.transform.position = transform.position + BulletspawnOffset;
                    Bullet.transform.rotation = transform.rotation;

                    Bullet.Spawn(transform.forward, Damage, TargetDamageable.GetTransform());
                }
            }

            yield return Wait;

            Damageables.RemoveAll(DisabledDamageables);            
        }

        AttackCoroutine = null;
    }

    private bool HasLineOfSightTo(Transform Target)
    {
        if (Physics.SphereCast(transform.position + BulletspawnOffset, SpherecastRadius, ((Target.position + BulletspawnOffset) - (transform.position + BulletspawnOffset)).normalized, out Hit, Collider.radius, Mask))
        {
            IDamageable damageable;
            if (Hit.collider.TryGetComponent<IDamageable>(out damageable))
            {
                return damageable.GetTransform() == Target;
            }
        }

        return false;
    }

    
}
