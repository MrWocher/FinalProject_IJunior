using UnityEngine;

public class MoveActions : IMoveable
{
    public void Move(Transform moveObj, Vector3 diraction, float speed, float _limitPosX = 2f)
    {
        moveObj.position += diraction * speed * Time.deltaTime;
        moveObj.position = new Vector3(Mathf.Clamp(moveObj.position.x, -_limitPosX, _limitPosX), moveObj.position.y, moveObj.position.z);
    }
	
	public void FixedMove(Transform moveObj, Vector3 diraction, float speed, float _limitPosX = 2f)
    {
        moveObj.position += diraction * speed * Time.fixedDeltaTime;
        moveObj.position = new Vector3(Mathf.Clamp(moveObj.position.x, -_limitPosX, _limitPosX), moveObj.position.y, moveObj.position.z);
    }
}
