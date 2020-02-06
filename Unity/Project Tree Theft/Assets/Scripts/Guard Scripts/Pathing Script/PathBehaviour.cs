using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathBehaviour : MonoBehaviour
{

    [Tooltip("A list of checkpoints, the int chosen for list size determined the amount of checkpoints. Checkpoints are objects with the CheckpointBehavior script. Position needs to be manually chosen for each checkpoint." +
        "Checkpoints go downward when an object is going towards the next checkpoint.")]
    public List<CheckpointBehaviour> checkpoints = new List<CheckpointBehaviour>();

    [Tooltip("Color chosen to visually see the path made by the list. NOTE: Check so the color is visible(Alpha Channel)")]
    public Color whatColor;
    public void OnValidate()
    {
        if (checkpoints.Contains(null))
        {
            Debug.LogWarning("Missing checkpoint reference(s).", this);
        }
    }
    
    public void OnDrawGizmos()
    {
        if (!checkpoints.Contains(null))
        {
            Gizmos.color = whatColor;
            for (int i = 0; i < checkpoints.Count; i++)
            {
                Vector3 from = checkpoints[i].transform.position;
                Vector3 to = checkpoints[(i + 1) % checkpoints.Count].transform.position;
                Gizmos.DrawLine(from, to);
            }
        }
    }

    public CheckpointBehaviour GetNextCheckpoint(CheckpointBehaviour checkpoint)
    {
        int i = checkpoints.IndexOf(checkpoint);
        return checkpoints[(i + 1) % checkpoints.Count];
    }
}
