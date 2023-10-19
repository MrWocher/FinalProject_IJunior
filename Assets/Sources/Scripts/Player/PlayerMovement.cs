using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInput
{

    [SerializeField] private float _dragSpeed;
    [SerializeField] private float _speed;

    private readonly MoveActions _moveActions = new MoveActions();
    private const string MouseX = "Mouse X";

    private bool _canMove = false;

    public Vector3 PlayerPosition => transform.position;

    private void FixedUpdate()
    {
        if (_canMove)
            _moveActions.FixedMove(transform, Vector3.forward, _speed);
    }

    public void Drag()
    {
        if(_canMove)
            transform.position += new Vector3(Input.GetAxis(MouseX) * _dragSpeed * Time.deltaTime, 0f, 0f);
    }

    public void PlayerDied()
    {
        _canMove = false;
    }

    public void PlayerDragContinue()
    {
        _canMove = true;
    }
}
