using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    private Rigidbody2D ball_rb;
    private GameObject DirectionalLine;
    private GameObject TrajectoryLine;
    private GameObject HitCircle;
    // Start is called before the first frame update
    void Start()
    {
        ball_rb = GetComponent<Rigidbody2D>();
        DirectionalLine = GameObject.FindGameObjectWithTag("DirectionLine");
        TrajectoryLine = GameObject.FindGameObjectWithTag("TrajectoryLine");
        HitCircle = GameObject.FindWithTag("Hit");
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
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, -Direction.normalized);

            Vector2 HitTrajectory = (new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y) - hit.point).normalized;

            Vector2 BounceTrajectory = Vector2.Perpendicular(HitTrajectory);

            Vector3 startPosition = new Vector3(this.transform.position.x - Direction.normalized.x * 0.5f, this.transform.position.y - Direction.normalized.y * 0.5f, -1);
            Vector3 endPosition = new Vector3(hit.point.x +Direction.normalized.x*0.15f, hit.point.y+Direction.normalized.y * 0.15f, -1);
            
            Vector3 trajectoryPosition = new Vector3(hit.collider.transform.position.x + HitTrajectory.x * 0.5f, hit.collider.transform.position.y + HitTrajectory.y*0.5f, -1);

            if ((-HitTrajectory.x > 0 && -HitTrajectory.y > 0)|| (-HitTrajectory.x < 0 && -HitTrajectory.y < 0))
            {
                BounceTrajectory = -BounceTrajectory;
            }
           
            
            

            DirectionalLine.GetComponent<LineRenderer>().enabled = true;
            HitCircle.GetComponent<SpriteRenderer>().enabled = true;

            

            DirectionalLine.GetComponent<LineRenderer>().SetPosition(0, startPosition);
            DirectionalLine.GetComponent<LineRenderer>().SetPosition(1, endPosition);
            


            if (hit.collider.tag == "Ball")
			{
                TrajectoryLine.GetComponent<LineRenderer>().enabled = true;
                TrajectoryLine.GetComponent<LineRenderer>().SetPosition(0, new Vector3(hit.point.x, hit.point.y, -1));
                TrajectoryLine.GetComponent<LineRenderer>().SetPosition(1, trajectoryPosition);
            }
            else if(hit.collider.tag == "Wall")
			{
    
                BounceTrajectory = Vector2.Reflect(endPosition.normalized,  hit.collider.transform.up);
                TrajectoryLine.GetComponent<LineRenderer>().enabled = false;
            }
            // Debug.Log($"x - {hit.transform.position.x} y - {hit.transform.position.y} x - {hit.point.x} y - {hit.point.y}");
            Vector3 bouncePosition = new Vector3(endPosition.x + BounceTrajectory.x * 0.5f, endPosition.y + BounceTrajectory.y * 0.5f, -1);
            DirectionalLine.GetComponent<LineRenderer>().SetPosition(2, bouncePosition);

            HitCircle.transform.position = endPosition;

            
        }
        if (Input.GetMouseButtonUp(0))
		{
            DirectionalLine.GetComponent<LineRenderer>().enabled = false;
            HitCircle.GetComponent<SpriteRenderer>().enabled = false;
            TrajectoryLine.GetComponent<LineRenderer>().enabled = false;

            GetComponent<Rigidbody2D>().AddForce(-Direction*1.3f, ForceMode2D.Impulse);
            Debug.Log("end");
        }

    }
		
}
