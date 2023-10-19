using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class BulletGate : DrumsBullet
{
    [SerializeField] private Animator _animator;
    [SerializeField] private DrumsBullet _drumsBullet;
    [SerializeField] private TextMeshPro _textAmount;
    [SerializeField] private int _bulletsAmount;

    private readonly int HitAnim = Animator.StringToHash("Hit");

    private Player _player;

    private void Start()
    {
        ChangeText(_textAmount, "x" + _bulletsAmount.ToString());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _player = player;
            if(_bulletsAmount == 1)
            {
                CreateGateBullet();
                gameObject.SetActive(false);
            }
            else if(_bulletsAmount > 1)
            {
                StartCoroutine(nameof(CreatePoolBullet));
            }
        }

        if (other.TryGetComponent(out Bullet bullet))
        {
            _animator.SetTrigger(HitAnim);
            bullet.StopShooting();
            bullet.Hit();
        }

    }

    private IEnumerator CreatePoolBullet()
    {
        float waitSecs = .075f;

        var waitForSeconds = new WaitForSeconds(waitSecs);

        int leftBullet = _player.Drum.MaxBulletsAmount - _player.Drum.CurrentBullet;

        int totalBullets = _bulletsAmount;

        while (leftBullet > 0 && totalBullets > 0)
        {
            CreateGateBullet();
            leftBullet--;
            totalBullets--;
            ChangeText(_textAmount, "x" + totalBullets.ToString());
            yield return waitForSeconds;
        }

        if(totalBullets <= 0)
            gameObject.SetActive(false);
    }

    private void ChangeText(TextMeshPro textObj, string txt)
    {
        textObj.text = txt;
    }

    private void CreateGateBullet()
    {
        DrumsBullet drumsBullet = Instantiate(_drumsBullet);
        drumsBullet.Initialize(transform.position, _player);
    }
}
