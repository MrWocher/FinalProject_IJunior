using UnityEngine;
using System.Linq;

public abstract class ShootActionParams : MonoBehaviour, IShootable
{
    protected ObjectPool<Bullet> ObjectPool;

    protected Bullet LastBullet;

    public abstract void Shoot(Transform shootPoint, Vector3 diraction);

    public virtual void CreatePoolsObj(Bullet bullet, int amount)
    {
        ObjectPool = new ObjectPool<Bullet>(amount);

        for (int i = 0; i < ObjectPool.Capacity; i++)
        {
            Bullet obj = Instantiate(bullet);
            ObjectPool.Items.Add(obj);
            obj.gameObject.SetActive(false);
        }
    }

    protected bool TryGetObject(out Bullet bullet)
    {
        bullet = ObjectPool.Items.FirstOrDefault(bullet => !bullet.IsActive);
        if (bullet)
            return true;
        return false;
    }
}
