using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public Rigidbody2D body = null;
    
    public float speed = 1.0f;

    public CheckpointBehaviour currentCheckpoint;
    public CheckpointBehaviour endingCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float TOLERANCE = 0.001f;
        Vector2 sourcePosition = body.transform.position;
        Vector2 targetPosition = currentCheckpoint.transform.position;
        Vector2 offset = targetPosition - sourcePosition;
        float distance = offset.magnitude;
        if (TOLERANCE < distance)
        {
            Vector2 direction = offset / distance;
            Vector2 velocity = speed * direction;
            Vector2 nextPosition = sourcePosition + Time.deltaTime * velocity;
            Vector2 targetToSource = sourcePosition - targetPosition;
            Vector2 targetToNext = nextPosition - targetPosition;
            if (0.0f < Vector3.Dot(targetToSource, targetToNext))
            {
                body.velocity = velocity;
            }
            else
            {
                currentCheckpoint = currentCheckpoint.Path.GetNextCheckpoint(currentCheckpoint);
            }
        }
        else
        {
            currentCheckpoint = currentCheckpoint.Path.GetNextCheckpoint(currentCheckpoint);
        }
    }
}
