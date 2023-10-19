using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;

    public void Play()
    {
        _ps.Stop();
        _ps.Play();
    }
}
