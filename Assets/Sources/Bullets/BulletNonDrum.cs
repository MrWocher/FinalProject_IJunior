using UnityEngine;

public class BulletNonDrum : MonoBehaviour
{
    [SerializeField] private HitEffect _hitEffect;

    private readonly MoveActions _moveAction = new MoveActions();

    private readonly float _speed = 10f;
    private Vector3 _diraction = Vector3.left;

    public void Initialize(Vector3 pos)
    {
        transform.SetPositionAndRotation(pos, Quaternion.Euler(90f, 0f, 90f));
    }

    private void Update()
    {
        _moveAction.Move(gameObject.transform, _diraction, _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out LevelUpPrism levelUpPrism))
        {
            levelUpPrism.Hit();
            HitEffect hitEffect = Instantiate(_hitEffect);
            hitEffect.Initialize(transform.position, new Vector3(-90f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}
