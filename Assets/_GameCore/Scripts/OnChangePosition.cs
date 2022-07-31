using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangePosition : MonoBehaviour
{
  public PolygonCollider2D hole2DCollider;
  public PolygonCollider2D ground2DCollider;

  public Collider GroundCollider;
  
  public MeshCollider generatedMeshCollider;
  private Mesh generatedMesh;

  public float initialScale = 0.5f;
  
  private void Start()
  {
    GameObject[] AllGOs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    foreach (var go in AllGOs)
    {
      if (go.layer == LayerMask.NameToLayer("Obstacles"))
      {
        Physics.IgnoreCollision(go.GetComponent<Collider>(), generatedMeshCollider,true);
      }
    }


  }
  
  private void OnTriggerEnter(Collider other)
  {
    Physics.IgnoreCollision(other,GroundCollider , true);
    Physics.IgnoreCollision(other,generatedMeshCollider,false);
  }

  private void OnTriggerExit(Collider other)
  {
    Physics.IgnoreCollision(other, GroundCollider, false);
    Physics.IgnoreCollision(other,generatedMeshCollider,true);
  }

  private void FixedUpdate()
  {
    if (transform.hasChanged == true)
    {
      var transform1 = transform;
      transform1.hasChanged = false;
      hole2DCollider.transform.position = new Vector2(transform1.position.x,transform1.position.z);
      hole2DCollider.transform.localScale = transform1.localScale * initialScale;
      MakeHole2D();
      Make3DMeshCollider();
    }
  }
  
  private void MakeHole2D()
  {
    Vector2[] PointPositions = hole2DCollider.GetPath(0);

    for (int i = 0; i < PointPositions.Length; i++)
    {
      PointPositions[i] = hole2DCollider.transform.TransformPoint(PointPositions[i]);
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
