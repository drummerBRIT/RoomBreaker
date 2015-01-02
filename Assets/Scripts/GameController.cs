using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
 {
 	public int Speed = 10;
 
	void Start()
	{
		Player.Create(Speed, Vector2.up, Vector2.zero);
	}
	
	void Update ()
	{
	}
}
