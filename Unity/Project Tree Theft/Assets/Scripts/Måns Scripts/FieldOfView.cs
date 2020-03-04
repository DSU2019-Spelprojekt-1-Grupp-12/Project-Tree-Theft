using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    #region Components
    MeshFilter meshFilter;
    Mesh mesh;

    #endregion

    #region Variables
    public float fov = 360f;
    public int rayCount = 200;
    public float viewDistance = 5f;
    Vector3 origin;
    float startingAngle;
    
    [SerializeField] private LayerMask layerMask;
    #endregion

    #region Core Functions
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void LateUpdate()
    {
        float angleIncrease = fov / rayCount;
        float angle = startingAngle;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(new Vector2(origin.x,origin.y), new Vector2(GetVectorFromAngle(angle).x,GetVectorFromAngle(angle).y), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = new Vector3 (raycastHit2D.point.x, raycastHit2D.point.y, -1);
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    #endregion

    #region Functions
    Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    float GetAngleFromVector (Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void setAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVector(aimDirection) + fov /2f;
    }

    #endregion

}
