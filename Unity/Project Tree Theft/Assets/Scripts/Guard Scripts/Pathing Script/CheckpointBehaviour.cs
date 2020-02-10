using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckpointBehaviour : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }

    public PathBehaviour Path
    {
        get
        {
            return transform.parent.GetComponent<PathBehaviour>();
        }
    }

    public static CheckpointBehaviour GetClosestCheckpoint(Vector3 position)
    {
        List<CheckpointBehaviour> checkpoints = FindObjectsOfType<CheckpointBehaviour>().ToList();
        float closestDistance = Vector3.Distance(position, checkpoints[0].transform.position);
        CheckpointBehaviour closestCheckpoint = checkpoints[0];
        for (int i = 1; i < checkpoints.Count; i++)
        {
            CheckpointBehaviour potentialCheckpoint = checkpoints[i];
            float potentialDistance = Vector3.Distance(position, potentialCheckpoint.transform.position);
            if (potentialDistance < closestDistance)
            {
                closestCheckpoint = potentialCheckpoint;
                closestDistance = potentialDistance;
            }
        }
        return closestCheckpoint;
    }
}
