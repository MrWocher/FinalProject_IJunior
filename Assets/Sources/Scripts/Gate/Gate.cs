using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [Header("TMPro Texts")]
    [SerializeField] private TMP_Text _titleTxt;
    [SerializeField] private TMP_Text _numberTxt;
    [SerializeField] private TMP_Text _perShootTxt;

    [Header("Meshes")]
    [SerializeField] private Material[] _positiveMaterials;
    [SerializeField] private Material[] _negativeMaterials;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
 
    private readonly string[] _titles = { "FireRate", "FireRange" };
    private readonly float[] _perShoots = { 0.5f, 1f, 2f, 5f };
    private readonly int HitAnim = Animator.StringToHash("Hit");

    private enum GateStatus { Positve, Negative }

    private GateStatus _currentStatus;
    private float _perShoot;
    private string _title;

    private int _minNumber = -50;
    private int _maxNumber = 50;

    private float _reduceNumber = 1000f;

    public float Number { get; set; }

    public void Start()
    {
        _title = _titles[Random.Range(0, _titles.Length)];
        _perShoot = _perShoots[Random.Range(0, _perShoots.Length - 1)];

        _titleTxt.text = _title;
        _perShootTxt.text = _perShoot.ToString();

        Number = Random.Range(_minNumber, _maxNumber);
        if(Number >= 0)
        {
            _currentStatus = GateStatus.Positve;
            InstallStatus(_currentStatus);
            ChangeNumberTxt(Number, "+");
        } else if(Number < 0)
        {
            _currentStatus = GateStatus.Negative;
            InstallStatus(_currentStatus);
            ChangeNumberTxt(Number, "");
        }

    }

    private void ChangeNumberTxt(float num, string type)
    {
        _numberTxt.text = type + num.ToString();
    }

    private void InstallStatus(GateStatus status)
    {
        if (status == GateStatus.Positve)
        {
            _meshRenderer.materials = _positiveMaterials;
        }
        else if (status == GateStatus.Negative)
        {
            _meshRenderer.materials = _negativeMaterials;
        }
    }

    public void Hit()
    {
        Number += _perShoot;
        if (Number >= 0 && _currentStatus == GateStatus.Negative)
        {
            _currentStatus = GateStatus.Positve;
            InstallStatus(_currentStatus);
        }
        if (Number >= 0) ChangeNumberTxt(Number, "+");
        if (Number < 0) ChangeNumberTxt(Number, "");

        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Hit();
            _animator.SetTrigger(HitAnim);
            bullet.StopShooting();
            bullet.Hit();
        }

        if(other.TryGetComponent(out Player player))
        {
            player.PlayerShoot.ShootRange += Number / _reduceNumber;
            player.PlayerShoot.ShootRange += Number / _reduceNumber;
            gameObject.SetActive(false);
        }
    }
}
