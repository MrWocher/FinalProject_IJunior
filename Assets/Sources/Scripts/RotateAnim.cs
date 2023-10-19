using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Rotate(Vector3.up * speed);
    }
}
