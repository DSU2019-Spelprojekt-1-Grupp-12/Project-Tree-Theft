using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineScript : MonoBehaviour
{
    [SerializeField] private float zoomBoundary = 1.75f;
    private GameObject centerPoint;
    private float defaultOrtSize;

    private void Awake(){ 
        centerPoint = FindObjectOfType<CamCenterPoint>().gameObject;
        defaultOrtSize = gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
    }

    private void Update(){ SetOrtographicSize(); }

    private void SetOrtographicSize(){
        var playerDistance = centerPoint.GetComponent<CamCenterPoint>().GetDistance();
        var newOrtSize = playerDistance / zoomBoundary;
        var minimumDistance = defaultOrtSize * zoomBoundary;

        if (playerDistance <= minimumDistance)
            gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = defaultOrtSize;
        else
            gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = newOrtSize;                   
    }
}
