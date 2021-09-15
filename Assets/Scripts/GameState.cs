using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<Sprite> colors;

    // Start is called before the first frame update    
    public SpriteRenderer Field;
    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
        SetBallColor();

    }
    void SetCamera()
	{
        float screenAspect = Screen.height / Screen.width;
        float fieldAspect = Field.bounds.size.x / Field.bounds.size.y;
        Camera.main.orthographicSize = Field.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
    void SetBallColor()
	{
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
		{
            
            int r = Random.Range(0, colors.Count - 1);
            Debug.Log(r);
            ball.GetComponent<SpriteRenderer>().sprite = colors[r];
            colors.RemoveAt(r);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
