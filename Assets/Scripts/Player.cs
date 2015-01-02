using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public int Speed { get; protected set;}
	public Vector2 Direction {get; protected set;}
	public Vector2 Position {get {return (Vector2)transform.position;} protected set{transform.position = (Vector3)value;}}

	protected Vector2 _targetDirection;
	protected bool _fire;
	
	public static Player Create(int speed, Vector2 direction, Vector2 position)
	{
		string prefabLocation = "Prefabs/Player";
		Player player = (Instantiate(Resources.Load(prefabLocation)) as GameObject).GetComponent<Player>();
		player.Speed = speed;
		player.Direction = direction;
		player._targetDirection = direction;
		player.Position = position;
		
		return player;
	}
	
	void Update ()
	{
		float fraction = Time.time - Mathf.Floor(Time.time);
		
		Debug.Log("fraction: " + fraction + " %: " + (fraction % (1.0/Speed)) + " 1/s: " + (1.0/Speed));
		
		ReadInput();
		
		bool shouldUpdate = (fraction % (1.0/Speed)) < 0.2;
		if(shouldUpdate)
		{
			UpdatePlayer();	
		}
	}
	
	void ReadInput()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		if(horizontal != 0)
		{
			_targetDirection = (horizontal > 0) ? Vector2.right :-Vector2.right;
		}
		else if(vertical != 0)
		{
			_targetDirection = (vertical > 0) ? Vector2.up : -Vector2.up;
		}
		
		if(Input.GetButton("Fire"))
		{
			_fire = true;
		}
	}
	
	void Move()
	{
		if(Direction.y == 0)
		{
			if((_targetDirection == Vector2.right) || _targetDirection == -Vector2.right)
			{
				Direction = Direction;
			}
			else
			{
				Direction = _targetDirection;
			}
		}
		if(Direction.x == 0)
		{
			if((_targetDirection == Vector2.up ) || _targetDirection == -Vector2.up)
			{
				Direction = Direction;
			}
			else
			{
				Direction = _targetDirection;
			}
		}
		
		Position += Direction;
	}
	
//	void Shoot()
//	{
//	
//	}
	
	void UpdatePlayer()
	{
		Move();
//		Shoot();
		
		_targetDirection = Direction;
		_fire = false;
	}
}
