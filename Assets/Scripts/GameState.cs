using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //Initializing our set of colors and main field
    public List<Sprite> Colors;
  
    public SpriteRenderer Field;

    void Start()
    {
        //Setting camera view and balls colors
        SetCamera();
        SetBallColor();

    }
    void SetCamera()
	{
        //Estimate aspect ratio of screen and set to orthographic size of camera
        float screenAspect = Screen.height / Screen.width;
        float fieldAspect = Field.bounds.size.x / Field.bounds.size.y;
        Camera.main.orthographicSize = Field.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
    void SetBallColor()
	{
        // Get all balls and set random color to them
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
		{
            
            int r = Random.Range(0, Colors.Count - 1);
            Debug.Log(r);
            ball.GetComponent<SpriteRenderer>().sprite = Colors[r];
            Colors.RemoveAt(r);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
