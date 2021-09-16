using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleState : MonoBehaviour
{
   

	public void OnTriggerEnter2D(Collider2D collision)
	{
		// Checking collision with type of object - with pocket.
		if (collision.tag == "Pocket")
		{
			// Checking on main ball or all other balls lack. Then reloading scene
			if (this.gameObject.tag == "Player")
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				
				if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)
				{
					SceneManager.LoadScene(0);
				}
				// If we have more, then 1 ball(not main), then just destroy it
				GameObject.Destroy(this.gameObject);
			}
			
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
