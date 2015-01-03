using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			//replace with game event
			Destroy(other.gameObject);
		}
		else
		{
			Debug.LogWarning("Collided with game object ["+other.gameObject.name+"] with tag ["+other.gameObject.tag+"]");
		}
	}	
}
