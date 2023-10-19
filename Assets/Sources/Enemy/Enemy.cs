using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Hit();
            GetComponent<Collider>().enabled = false;
        }
    }
}
