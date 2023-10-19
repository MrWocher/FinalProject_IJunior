using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private HitEffect _hitEffect;
    [SerializeField] private MoneyAmountPS _moneyAmountPS;

    private int _money;
    private int _minMoneyAmount = 50;
    private int _maxMoneyAmount = 100;

    private void Start()
    {
        _money = Random.Range(_minMoneyAmount, _maxMoneyAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            MoneyView.MoneyAdded?.Invoke(_money);

            HitEffect hitEffect = Instantiate(_hitEffect);
            hitEffect.Initialize(transform.position + new Vector3(0f, 0.5f, 0f), new Vector3(-90f, 0f, 0f));

            MoneyAmountPS moneyAmount = Instantiate(_moneyAmountPS);
            moneyAmount.Initialize(transform.position, _money.ToString());
            Destroy(gameObject);
        }
    }
}
