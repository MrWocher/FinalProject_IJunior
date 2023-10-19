using UnityEngine;
using DG.Tweening;

public class DrumsBullet : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private RotateAnim _rotateAnim;

    private Player player;

    private Vector3 _targetScale = new Vector3(.3f, .3f, .3f);
    private Vector3 _targetJump = new Vector3(0f, 0f, -0.25f);

    private float _duractionScale = 0.2f;
    private float _jumpPower = 0.8f;
    private int _jumpsNum = 1;
    private float _duractionJump = 0.3f;

    public void Initialize(Vector3 pos, Player player)
    {
        _collider.enabled = false;
        _rotateAnim.enabled = false;
        transform.SetPositionAndRotation(pos, Quaternion.Euler(90f, -45f, 0f));
        OnPlayerEnter(player);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            if(player.Drum.MaxBulletsAmount > player.Drum.CurrentBullet)
            {
                OnPlayerEnter(player);
            }
        }
    }

    private void OnPlayerEnter(Player player)
    {
        this.player = player;
        _collider.enabled = false;
        _rotateAnim.enabled = false;
        DOTween.Sequence()
            .AppendCallback(SetBulletParent)
            .Append(transform.DOScale(_targetScale, _duractionScale));
        DOTween.Sequence()
            .Append(transform.DOLocalJump(_targetJump, _jumpPower, _jumpsNum, _duractionJump))
            .AppendCallback(OnAddBullet);
    }

    private void SetBulletParent()
    {
        transform.SetParent(player.Drum.transform, true);
    }

    private void OnAddBullet()
    {
        player.Drum.OnAddBullet();
        Destroy(gameObject);
    }
}
