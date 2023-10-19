using UnityEngine;
public interface IMoveable
{
    public void Move(Transform moveObj, Vector3 diraction, float speed, float _limitPosX);
	public void FixedMove(Transform moveObj, Vector3 diraction, float speed, float _limitPosX);
}

