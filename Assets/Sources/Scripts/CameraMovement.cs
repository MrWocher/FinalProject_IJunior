using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private Vector3 _cameraRotation;

    private readonly float _followSpeed = 5f;

    private bool _finishPhase = false;

    private void Update()
    {
        if(_finishPhase )
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_cameraRotation), _followSpeed * Time.deltaTime);

            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, _playerMovement.PlayerPosition.z + _cameraOffset.z),
                new Vector3(_playerMovement.PlayerPosition.x, 4f, _playerMovement.PlayerPosition.z + _cameraOffset.z), _followSpeed * Time.deltaTime);
            return;
        }

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, _playerMovement.PlayerPosition.z + _cameraOffset.z),
            new Vector3(_playerMovement.PlayerPosition.x, transform.position.y, _playerMovement.PlayerPosition.z + _cameraOffset.z), _followSpeed * Time.deltaTime);
    }

    public void OnFinishPhase()
    {
        _finishPhase = true;
    }
}
