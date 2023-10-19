using UnityEngine;
using DG.Tweening;

public class DeleteParts : MonoBehaviour
{
    private float _timeToInvoke = 1.5f;
    private float _duraction = 3f;

    private void OnEnable()
    {
        Invoke(nameof(DeletePart), _timeToInvoke);
    }

    private void DeletePart()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, _duraction))
            .AppendCallback(() => Destroy(gameObject));
    }
}
