using UnityEngine;

public class FollowPlayer : MonoBehaviour, IFollowable
{
    [SerializeField] private PlayerMovement _playerPosition;

    [SerializeField] private Vector3 _tableOffset;

    private void Update()
    {
        Follow(transform, _playerPosition.transform, _tableOffset);
    }

    public void Follow(Transform follower, Transform follow, in Vector3 offset)
    {
        follower.position = new Vector3(follow.position.x + offset.x, follower.position.y, follow.position.z + offset.z);
    }
}
