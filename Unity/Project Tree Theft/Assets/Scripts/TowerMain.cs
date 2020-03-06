using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour
{



    public LineRenderer lineRenderer;
    public GameObject tower;
    public float sightRange;
    //Rotation  (Rotate This One)
    public Rigidbody2D sightArea;

    public PolygonCollider2D sight;

    public float rotateSpeed;

    void Start()
    {
        

    }
    void Update()
    {
        sightArea.gameObject.transform.Rotate(0, 0, rotateSpeed);
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, sightArea.transform.up, sightRange);
        lineRenderer.SetPosition(0, gameObject.transform.position);
        if (hit.collider != null && hit.collider.CompareTag("Wall") || hit.collider != null && hit.collider.CompareTag("Tree"))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, gameObject.transform.position + sightArea.transform.up * sightRange);
        }

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            GameLogic.GameOverLose();
        }

    }
}
