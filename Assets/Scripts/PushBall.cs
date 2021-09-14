using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    private Rigidbody2D ball_rb;
    // Start is called before the first frame update
    void Start()
    {
        ball_rb = GetComponent<Rigidbody2D>();
    }
    Vector2 FingerPosition = new Vector2();
    Vector2 Direction = new Vector2();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
		{
           
           
            
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


            FingerPosition = worldPosition;
            Direction = FingerPosition - new Vector2(transform.position.x, transform.position.y);

            
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -Direction);
            Debug.Log($"x - {FingerPosition.x} y - {FingerPosition.y}");
            Debug.Log($"x - {hit.transform.position.x} y - {hit.transform.position.y}");

            GameObject.FindGameObjectWithTag("DirectionLine").GetComponent<LineRenderer>().enabled = true;
                
            Vector3 startPosition = new Vector3(this.transform.position.x - Direction.normalized.x*0.5f, this.transform.position.y-Direction.normalized.y*0.5f, -1);

            GameObject.FindGameObjectWithTag("DirectionLine").GetComponent<LineRenderer>().SetPosition(0, startPosition);
            GameObject.FindGameObjectWithTag("DirectionLine").GetComponent<LineRenderer>().SetPosition(1, new Vector3( hit.point.x,hit.point.y,-1));



        }
        if (Input.GetMouseButtonUp(0))
		{
            GameObject.FindGameObjectWithTag("DirectionLine").GetComponent<LineRenderer>().enabled = false;


            GetComponent<Rigidbody2D>().AddForce(-Direction*1.3f, ForceMode2D.Impulse);
            Debug.Log("end");
        }

    }
		
}
