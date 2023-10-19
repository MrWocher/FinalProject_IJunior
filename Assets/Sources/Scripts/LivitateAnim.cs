using UnityEngine;
using DG.Tweening;

public class LivitateAnim : MonoBehaviour
{
    [SerializeField] private Vector3 _initScale;

    private float _targetScaleMax = 1.1f;
    private float _zeroDuraction = 0f;
    private float _animDuraction = 0.5f;
    private int _loops = -1;

    private Vector3 _targetScale
    {
        get { return transform.localScale *= _targetScaleMax; }
    }

    private void OnEnable()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(_initScale, _zeroDuraction))
            .Append(transform.DOScale(_targetScale, _animDuraction))
            .Append(transform.DOScale(_initScale, _animDuraction))
            .SetLoops(_loops);
    }
}
