using UnityEngine;
using TMPro;

public class LevelUpPrism : MonoBehaviour
{
    [SerializeField] private TextMeshPro _hitsText;
    [SerializeField] private Animator _jailAnimator;
    [SerializeField] private GameObject _jail;
    [SerializeField] private GameObject _jailParts;
    [SerializeField] private LevelUP _levelUP;

    private readonly int HitAnim = Animator.StringToHash("Hit");

    private int _hits = 6;

    public int Hits { get { return _hits; } }

    private void OnEnable()
    {
        _hitsText.text = Hits.ToString();
    }

    public void Hit()
    {
        _hits--;
        _jailAnimator.SetTrigger(HitAnim);
        _hitsText.text = Hits.ToString();

        if(_hits <= 0)
        {
            _jail.SetActive(false);
            _jailParts.SetActive(true);
            _levelUP.Move();

        }
    }

}
