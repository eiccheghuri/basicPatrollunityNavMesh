using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolWaypoints : MonoBehaviour
{
    [SerializeField]
    private float max_waittime=3f;

    [SerializeField]
    private float direction_probability=0.2f;

    [SerializeField]
    private List<wayPoint> wayPointList;


    private int current_waypoint_index=0;
    private NavMeshAgent enemy_agent;

    [SerializeField]
    private bool is_waiting;
    private bool is_moving;
    private bool patroll_forward;
    private float wait_timer;
    private bool waiting;
    
    


    public void Start()
    {

        enemy_agent = GetComponent<NavMeshAgent>();
        if(enemy_agent==null)
        {
            Debug.Log("please add nav mesh agent"+gameObject.name);
        }
        else
        {
            if(wayPointList!=null && wayPointList.Count>=2)
            {
                current_waypoint_index = 0;
                setDestination();
                
            }
            else
            {
                Debug.Log("not enough way-points for patrolling");
            }
        }




    }//start will be called one time 


    public void Update()
    {

        destinationMeasure();

        if (waiting)
        {
            wait_timer = wait_timer + Time.deltaTime;
            if (wait_timer >= max_waittime)
            {
                waiting = false;
                changeWaypoint();
                setDestination();

            }

        }



    }//update will be called every frame


    public void destinationMeasure()
    {
        if(is_moving && enemy_agent.remainingDistance<=1.0f)
        {

            is_moving = false;
            if(is_waiting)
            {
                waiting = true;
                wait_timer = 0f;


            }
            else
            {
                changeWaypoint();
                setDestination();
            }

        }

        


    }





    public void setDestination()
    {
        if(wayPointList!=null)
        {
            Vector3 targetVector = wayPointList[current_waypoint_index].transform.position;
            enemy_agent.SetDestination(targetVector);
            is_moving = true;

        }
        
    }//setdestination method


    public void changeWaypoint()
    {
        if(Random.Range(0f,1f)<=direction_probability)
        {
            patroll_forward = !patroll_forward;

        }

        if(patroll_forward)
        {

            current_waypoint_index = (current_waypoint_index+1)%wayPointList.Count;
        }
        else
        {
            if(--current_waypoint_index<0)
            {
                current_waypoint_index = wayPointList.Count - 1;
            }
        }



    }//change waypoint method






    
}//patroll waypoints clas
