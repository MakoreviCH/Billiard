using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleState : MonoBehaviour
{
   

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Pocket")
		{
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
				GameObject.Destroy(this.gameObject);
			}
			
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
