using UnityEngine;

interface IFollowable
{
    public void Follow(Transform follower, Transform follow, in Vector3 offset);
}
