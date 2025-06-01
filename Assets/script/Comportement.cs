using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Comportement : Agent
{

    private float previousDistanceToTarget;
    [SerializeField] private Transform[] targetSpawnPoints;

    public GameObject Target;
    [SerializeField] private Collider spawnArea; 
    private Rigidbody rb;
    public float speed = 20;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        
        this.transform.localPosition = new Vector3(-2.32f, 0.6f, 15.17f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        
        int index = Random.Range(0, targetSpawnPoints.Length);
        Target.transform.localPosition = targetSpawnPoints[index].position;

        
        previousDistanceToTarget = Vector3.Distance(this.transform.localPosition, Target.transform.localPosition);
    }


    private Vector3 GetRandomPositionInSpawnArea()
    {
        Bounds bounds = spawnArea.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            0.6f,
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
        //sensor.AddObservation(Target.transform.localPosition);
        sensor.AddObservation(rb.velocity);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 agentMouvement = Vector3.zero;
        agentMouvement.x = actions.ContinuousActions[0];
        agentMouvement.z = actions.ContinuousActions[1];
        rb.AddForce(agentMouvement * speed);

        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.transform.localPosition);

        
        if (distanceToTarget < 1.5f)
        {
            SetReward(3.0f);
            EndEpisode();
        }

        
        if (this.transform.localPosition.y < 0)
        {
            SetReward(-1.0f);
            EndEpisode();
        }

       
        AddReward(-0.1f); 

       
        float moveTowardReward = (previousDistanceToTarget - distanceToTarget) * 0.01f;
        AddReward(moveTowardReward);

       
        previousDistanceToTarget = distanceToTarget;
    }


    //public override void Heuristic(in ActionBuffers actionsOut)
    //{
    //    var continuousActionsOut = actionsOut.ContinuousActions;
    //    continuousActionsOut[0] = Input.GetAxis("Horizontal");
    //    continuousActionsOut[1] = Input.GetAxis("Vertical");
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }
}
