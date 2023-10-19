using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private UnityEvent _finishEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _finishEvent?.Invoke();
        }
    }
}
