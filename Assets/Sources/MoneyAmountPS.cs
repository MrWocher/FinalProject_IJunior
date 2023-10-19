using DG.Tweening;
using UnityEngine;
using TMPro;

public class MoneyAmountPS : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    private float _duractionMove = 0.5f;
    private float _duractionScale = 0.5f;

    public void Initialize(Vector3 pos, string text)
    {
        transform.SetPositionAndRotation(new Vector3(pos.x, 0.2f, pos.z), Quaternion.Euler(45f, 0f, 0f));
        _text.text = "+" + text;

        DOTween.Sequence()
            .Append(transform.DOMove(new Vector3(transform.position.x, 1.75f, transform.position.z), _duractionMove))
            .Append(transform.DOScale(Vector3.zero, _duractionScale))
            .AppendCallback(() => Destroy(gameObject));
    }
}
