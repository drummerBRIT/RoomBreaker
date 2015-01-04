using UnityEngine;
using System.Collections;

public class SnakeHead : MonoBehaviour 
{
	public int Speed { get; protected set;}
	public Vector2 Direction {get; protected set;}
	public Vector2 Position {get {return (Vector2)transform.position;} protected set{transform.position = (Vector3)value;}}

	protected Vector2 _targetDirection;
	protected bool _fire;
	protected float _timer;
	
	public static SnakeHead Create(int speed, Vector2 direction, Vector2 position)
	{
		string prefabLocation = "Prefabs/Snake/Head";
		SnakeHead player = (Instantiate(Resources.Load(prefabLocation)) as GameObject).GetComponent<SnakeHead>();
		player.Speed = speed;
		player.Direction = direction;
		player._targetDirection = direction;
		player.Position = position;
		
		return player;
	}
	
	void Update ()
	{
		ReadInput();
		
		if(_fire)
		{
			Shoot();
		}
	}
	
	void FixedUpdate()
	{
		if(_timer >= (1.0/Speed))
		{
			UpdatePosition();
			_timer = 0.0f;
		}
		
		_timer += Time.fixedDeltaTime;
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
	
	void Shoot()
	{
		string prefabLocation = "Prefabs/Ammunition/Base Amunnition";
		GameObject gameObject = (Instantiate(Resources.Load(prefabLocation)) as GameObject);
		gameObject.transform.position = Position;
		
		Rigidbody2D rBody = gameObject.GetComponent<Rigidbody2D>();
		rBody.velocity = Direction * Speed * 2;
		_fire = false;
	}

	void UpdatePosition()
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
		_targetDirection = Direction;
	}
	
}