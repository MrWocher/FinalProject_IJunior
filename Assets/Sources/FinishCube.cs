using UnityEngine;
using TMPro;

public class FinishCube : Enemy
{
    [SerializeField] private int Hits;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;
    [SerializeField] private HitEffect _smokeEffect;

    private readonly int HitAnim = Animator.StringToHash("Hit");

    private void Start()
    {
        ChangeHitText();
    }

    private void ChangeHitText()
    {
        _text.text = Hits.ToString();
    }

    private void Hit()
    {
        Hits--;
        ChangeHitText();

        if (Hits <= 0)
        {
            _text.gameObject.SetActive(false);
            Destroy(gameObject);

            HitEffect hitEffect = Instantiate(_smokeEffect);
            hitEffect.Initialize(transform.position, new Vector3(-90f, 0f, 0f));
            return;
        }

        _animator.SetTrigger(HitAnim);

    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Died();
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            Hit();
            bullet.StopShooting();
            bullet.Hit();
        }
    }

}
