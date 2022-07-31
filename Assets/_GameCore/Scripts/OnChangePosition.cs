using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangePosition : MonoBehaviour
{
  public PolygonCollider2D hole2DCollider;
  public PolygonCollider2D ground2DCollider;

  public MeshCollider generatedMeshCollider;
  private Mesh generatedMesh;

  private void FixedUpdate()
  {
    if (transform.hasChanged == true)
    {
      var transform1 = transform;
      transform1.hasChanged = false;
      hole2DCollider.transform.position = new Vector2(transform1.position.x,transform1.position.z);
      MakeHole2D();
      Make3DMeshCollider();
    }
  }
  
  private void MakeHole2D()
  {
    Vector2[] PointPositions = hole2DCollider.GetPath(0);

    for (int i = 0; i < PointPositions.Length; i++)
    {
      PointPositions[i] += (Vector2)hole2DCollider.transform.position;
    }

    ground2DCollider.pathCount = 2;
    ground2DCollider.SetPath(1,PointPositions);
  }

  private void Make3DMeshCollider()
  {
    if (generatedMesh != null) Destroy(generatedMesh);
    generatedMesh = ground2DCollider.CreateMesh(true, true);
    generatedMeshCollider.sharedMesh = generatedMesh;

  }
  
  
}
