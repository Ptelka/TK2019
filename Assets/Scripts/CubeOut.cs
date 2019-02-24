 

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeOut : MonoBehaviour
{
    private Vector3[] vertices;
     private Vector3 v3FrontTopLeft;
     private Vector3 v3FrontTopRight;
     private Vector3 v3FrontBottomLeft;
     private Vector3 v3FrontBottomRight;
     private Vector3 v3BackTopLeft;
     private Vector3 v3BackTopRight;
     private Vector3 v3BackBottomLeft;
     private Vector3 v3BackBottomRight;

     private LineRenderer lineRenderer;

     private void Start()
     {
         vertices = new Vector3[9];
         var LR = new GameObject("LineR", typeof(LineRenderer));

         lineRenderer = LR.GetComponent<LineRenderer>();

         CalcPositons();
         
         lineRenderer.positionCount = vertices.Length;
         lineRenderer.SetPositions(vertices);
         lineRenderer.positionCount = vertices.Length;
     }

     void CalcPositons()
     {            
         Bounds bounds;
         BoxCollider bc = GetComponent<BoxCollider>();
         if (bc != null)
             bounds = bc.bounds;
         else
             return;

         Vector3 v3Center = bounds.center;
         Vector3 v3Extents = bounds.extents;

         vertices[0] = v3FrontTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  
         vertices[1] = v3FrontTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  
         vertices[2] = v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);                  
         vertices[3] = v3FrontBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  
         vertices[4] = v3BackBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);
         vertices[5] = v3BackBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);
         vertices[6] = v3BackTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  
         vertices[7] = v3BackTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);
         vertices[8] = v3FrontTopLeft;
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Topornicy")
        {
            GameControll.Instance.EndGame(Team.Topornicy);
        }
        else if (other.tag == "Wlocznicy")
        {
            GameControll.Instance.EndGame(Team.Wlocznicy);
        }
    }
}
 