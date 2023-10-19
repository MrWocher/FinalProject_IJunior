using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public PlayerShoot PlayerShoot;
    public Drum Drum;

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private StartGame _startGame;

    private readonly int DiedAnimation = Animator.StringToHash("Die");

    private Rigidbody _rigidbody;

    private float _diedForce = 7f;
    private float _hitForce = 10f;

    private float _shootZonePosX = 0f;
    private float _duractionToShootZonePosX = 0.4f;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Died()
    {
        _startGame.OnGameFinish();
        _startGame.OnGameOver();
        _animator.SetTrigger(DiedAnimation);
        _rigidbody.AddForce(-transform.forward * _diedForce, ForceMode.Impulse);
    }

    public void Hit()
    {
        Drum.DeleteBullet();
        _rigidbody.AddForce(-transform.forward * _hitForce, ForceMode.Impulse);
		
		_audioSource.Play();
    }

    public void OnShootZone()
    {
        _startGame.OnStopPlayer();
        transform.DOMoveX(_shootZonePosX, _duractionToShootZonePosX);
    }
}
