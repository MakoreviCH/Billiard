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
				GameObject.Destroy(this.gameObject);
				if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
				{
					SceneManager.LoadScene(0);
				}
			}
			
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
