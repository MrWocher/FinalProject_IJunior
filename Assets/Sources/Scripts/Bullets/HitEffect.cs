using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void Initialize(Vector3 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
        _particleSystem.Play();
    }

    private void Update()
    {
        if(_particleSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
