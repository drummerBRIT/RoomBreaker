using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
 {
 	public int Speed = 10;
 
	void Start()
	{
		SnakeHead.Create(Speed, Vector2.up, Vector2.zero);
	}
	
	void Update ()
	{
		
	}
}
