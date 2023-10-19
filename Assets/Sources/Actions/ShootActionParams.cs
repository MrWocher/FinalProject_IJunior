using UnityEngine;

public abstract class ShootActionParams : MonoBehaviour, IShootable
{
    protected ObjectPool<Bullet> ObjectPool;

    protected Bullet LastBullet;

    private int _initPoolNum = 10;

    public abstract void Shoot(Transform shootPoint, Vector3 diraction);

    public virtual void CreatePoolsObj(Bullet bullet)
    {
        ObjectPool = new ObjectPool<Bullet>(_initPoolNum);

        for (int i = 0; i < ObjectPool.Capacity; i++)
        {
            Bullet obj = Instantiate(bullet);
            ObjectPool.Items.Add(obj);
            obj.gameObject.SetActive(false);
        }
    }

    protected Bullet GetFirstUnactiveObj(ref Bullet bullet)
    {
        foreach(Bullet obj in ObjectPool.Items)
        {
            if (!obj.IsActive && obj != bullet)
            {
                bullet = obj;
                return obj;
            }
            else
                continue;
        }
        return null;
    }
}
