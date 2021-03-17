using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WallGenerator
{
    public class MeshGenerator : MonoBehaviour
    {
        [SerializeField] Material wallMat;

        List<Vector2> vertecesList;

        private void Start()
        {
            vertecesList = new List<Vector2>();
            vertecesList.Add(Vector2.zero);
        }

        public Vector2[] CreateArrayForFloor() 
        {
            int sizeOfArray;

            if (vertecesList[0] == vertecesList[vertecesList.Count - 1])
            {
                sizeOfArray = vertecesList.Count - 1;
            }
            else
            {
                sizeOfArray = vertecesList.Count;
            }

            Vector2[] _vertices2D = new Vector2[sizeOfArray];

            for (int i = 0; i < sizeOfArray; i++)
            {
                _vertices2D[i] = vertecesList[i];
            }

            return _vertices2D;
        }

        #region GenerateWallMesh
        public void CreateWallMesh(Vector2 _pointStart, Vector2 _pointEnd, float _height)
        {
            Mesh _mesh = new Mesh();
            float _wallLenght = Vector2.Distance(_pointStart, _pointEnd);
            int[] _triangles = new int[12];

            Vector3[] _vertices = new Vector3[]
            {
                new Vector3(_pointStart.x, 0, _pointStart.y),
                new Vector3(_pointStart.x, _height, _pointStart.y),
                new Vector3(_pointEnd.x, 0, _pointEnd.y),
                new Vector3(_pointEnd.x, _height, _pointEnd.y),
                new Vector3(_pointStart.x, 0, _pointStart.y),
                new Vector3(_pointStart.x, _height, _pointStart.y),
                new Vector3(_pointEnd.x, 0, _pointEnd.y),
                new Vector3(_pointEnd.x, _height, _pointEnd.y)
            };

            Vector2[] _uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(_wallLenght / _vertices[1].y , 0),
                new Vector2(_wallLenght / _vertices[1].y , 1),
                new Vector2(_wallLenght / _vertices[1].y, 1),
                new Vector2(_wallLenght / _vertices[1].y , 0),
                new Vector2(0, 1),
                new Vector2(0, 0)
            };

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

            vertecesList.Add(new Vector2(_vertices[2].x, _vertices[2].z));

            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _mesh.uv = _uv;

            _mesh.RecalculateNormals();
            _mesh.RecalculateBounds();
            _mesh.RecalculateTangents();

            GameObject _go = new GameObject("WallMesh", typeof(MeshFilter), typeof(MeshRenderer));
            _go.GetComponent<MeshFilter>().sharedMesh = _mesh;
            _go.GetComponent<MeshRenderer>().sharedMaterial = wallMat;
        }
        #endregion
    }
}
