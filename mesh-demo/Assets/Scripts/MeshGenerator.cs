using System;
using System.Linq;
using UnityEngine;
using WallGenerator.Triangulator;

namespace WallGenerator
{
    public class MeshGenerator : MonoBehaviour
    {
        [SerializeField] Material wallMat;
        [SerializeField] Material floorMat;

        Vector2[] prevVerteces;
        Vector2[] actualVerteces;

        Vector2[]vertices2D;
        int[] indices;

        bool isTheFirstWall = true;

        #region GenerateFloorMesh
        public void CreateFloor()
        {
            Triangulator.Triangulator.Triangulate(actualVerteces, WindingOrder.Clockwise, out vertices2D, out indices);

            Mesh _floorMesh = new Mesh();
            GameObject _floor;
            Color[] _colors = Enumerable.Range(0, actualVerteces.Length).Select(i => Color.grey).ToArray();
            Vector3[] _vertices3D = Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);

            for (int i = 0; i < _vertices3D.Length; i++)
            {
                _vertices3D[i].z = _vertices3D[i].y;
                _vertices3D[i].y = 0;
            }

            _floorMesh.vertices = _vertices3D;
            _floorMesh.triangles = indices;
            _floorMesh.RecalculateNormals();

            _floor = new GameObject("FloorMesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(FloorMesh));
            _floor.GetComponent<MeshFilter>().sharedMesh = _floorMesh;
            _floor.GetComponent<MeshRenderer>().sharedMaterial = floorMat;
        }

        void CreateFloorVerticesArray()
        {
            if (isTheFirstWall)
            {
                prevVerteces = actualVerteces;
                isTheFirstWall = false;
            }
            else
            {
                int _arraySize = prevVerteces.Length + actualVerteces.Length;
                int _indx = prevVerteces.Length;
                Vector2[] _combineVerteces = new Vector2[_arraySize];

                for (int i = 0; i < prevVerteces.Length; i++)
                {
                    _combineVerteces[i] = prevVerteces[i];
                }
                for (int i = 0; i < actualVerteces.Length; i++)
                {
                    _combineVerteces[_indx] = actualVerteces[i];
                    _indx++;
                }

                actualVerteces = _combineVerteces;
                prevVerteces = _combineVerteces;
            }
        }

        #endregion

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


            actualVerteces = new Vector2[]
            {
                new Vector2(_vertices[0].x, _vertices[0].z),
                new Vector2(_vertices[2].x, _vertices[2].z),
            };

            CreateFloorVerticesArray();

            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _mesh.uv = _uv;

            _mesh.RecalculateNormals();

            GameObject _go = new GameObject("WallMesh", typeof(MeshFilter), typeof(MeshRenderer));
            _go.GetComponent<MeshFilter>().sharedMesh = _mesh;
            _go.GetComponent<MeshRenderer>().sharedMaterial = wallMat;
        }
        #endregion
    }
}
