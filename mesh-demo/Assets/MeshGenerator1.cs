using System;
using System.Collections;
using System.Collections.Generic;
using Triangulator;
using UnityEngine;

public class MeshGenerator1 : MonoBehaviour
{
   
    const float WALL_HEIGHT = 3;

    [SerializeField] Material _customMat;

    Vector2[] _uvPoints = { new Vector2(0, 5),  new Vector2(0, 20),  new Vector2(10, 20),  new Vector2(10, 25),
             new Vector2(20, 25),  new Vector2 (20, 0), new Vector2 (10, 0), new Vector2 (10, 5), new Vector2(0, 5)};

    void Start()
    {
        for (int i = 0; i < _uvPoints.Length - 1; i++)
        {
            GenerateWall(_uvPoints[i], _uvPoints[i + 1], WALL_HEIGHT);
        }
    }

    void GenerateWall(Vector2 _pointStart, Vector2 _pointEnd, float _height) 
    {
        Mesh _mesh = new Mesh();
        Vector3[] _vertices = new Vector3[8];
        Vector2[] _uv = new Vector2[8];
        int[] _triangles = new int[12];

        _vertices[0] = new Vector3(_pointStart.x, 0, _pointStart.y);
        _vertices[1] = new Vector3(_pointStart.x, _height, _pointStart.y);
        _vertices[2] = new Vector3(_pointEnd.x, 0 ,_pointEnd.y);
        _vertices[3] = new Vector3(_pointEnd.x, _height, _pointEnd.y);
        _vertices[4] = new Vector3(_pointStart.x, 0, _pointStart.y);
        _vertices[5] = new Vector3(_pointStart.x, _height, _pointStart.y);
        _vertices[6] = new Vector3(_pointEnd.x, 0, _pointEnd.y);
        _vertices[7] = new Vector3(_pointEnd.x, _height, _pointEnd.y);


        foreach (var item in _vertices)
        {
            Debug.Log(item);
        }

        float _wallLenght = Vector2.Distance(_pointStart, _pointEnd);

        _uv[0] = new Vector2(0, 0);
        _uv[1] = new Vector2(0, 2);
        _uv[2] = new Vector2(_wallLenght / _vertices[1].y * 2, 0);
        _uv[3] = new Vector2(_wallLenght / _vertices[1].y * 2, 2);
        _uv[4] = new Vector2(_wallLenght / _vertices[1].y * 2, 2);
        _uv[5] = new Vector2(_wallLenght / _vertices[1].y * 2, 0);
        _uv[6] = new Vector2(0, 2);
        _uv[7] = new Vector2(0, 0);

        _triangles[0] = 0;
        _triangles[1] = 1;
        _triangles[2] = 3;

        _triangles[3] = 0;
        _triangles[4] = 3;
        _triangles[5] = 2;

        _triangles[6] = 4;
        _triangles[7] = 7;
        _triangles[8] = 5;

        _triangles[9] = 4;
        _triangles[10] = 6;
        _triangles[11] = 7;

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.uv = _uv;

        _mesh.RecalculateNormals();

        GameObject _go = new GameObject("TypeMesh", typeof(MeshFilter), typeof(MeshRenderer));
        _go.GetComponent<MeshFilter>().sharedMesh = _mesh;
        _go.GetComponent<MeshRenderer>().sharedMaterial = _customMat;
    }

    private void GenerateMesh()
    {
        Mesh _mesh = new Mesh();
        Vector3[] _vertices = new Vector3[4];
        int[] _triangles = new int[6];

        Vector2[] _uv = new Vector2[_vertices.Length];


        _vertices[0] = new Vector3(0, 0 , 0);
        _vertices[1] = new Vector3(0, 1 , 0);
        _vertices[2] = new Vector3(1, 1 , 0);
        _vertices[3] = new Vector3(1, 0 , 0);

        _uv[0] = new Vector2(0, 0.25f);
        _uv[1] = new Vector2(0, 1);
        _uv[2] = new Vector2(0.75f, 1);
        _uv[3] = new Vector2(0.75f, 0.25f);

        _triangles[0] = 0;
        _triangles[1] = 1;
        _triangles[2] = 2;

        _triangles[3] = 2;
        _triangles[4] = 3;
        _triangles[5] = 0;

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.uv = _uv;

        _mesh.RecalculateNormals();

        GameObject _go = new GameObject("TypeMesh", typeof(MeshFilter), typeof(MeshRenderer));
        _go.GetComponent<MeshFilter>().sharedMesh = _mesh;
        _go.GetComponent<MeshRenderer>().sharedMaterial = _customMat;
    }
}
