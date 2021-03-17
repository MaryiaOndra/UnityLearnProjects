using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallGenerator
{
    public class FloorMeshGenerator 
    {
        GameObject floor;
        Mesh floorMesh;
        Vector3[] fVertices;
        Vector2[] fUV;
        int[] fTriangles;

        public void GenerateFloor(Vector2[] data, Material floorMat)
        {
            Triangulator triangulator = new Triangulator(data);
            fTriangles = triangulator.Triangulate();
            fVertices = new Vector3[data.Length];
            fUV = new Vector2[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                fUV[i] = data[i];
            }

            for (int i = 0; i < fVertices.Length; i++)
            {
                fVertices[i] = new Vector3(data[i].x, 0, data[i].y);
            }

            floor = new GameObject("Floor", typeof(MeshFilter), typeof(MeshRenderer));
            floorMesh = new Mesh();

            floor.GetComponent<MeshRenderer>().sharedMaterial = floorMat;
            floorMesh = floor.GetComponent<MeshFilter>().mesh;

            floorMesh.vertices = fVertices;
            floorMesh.triangles = fTriangles;
            floorMesh.uv = fUV;


            floorMesh.RecalculateNormals();
            floorMesh.RecalculateBounds();
            floorMesh.RecalculateTangents();
        }
    }
}
