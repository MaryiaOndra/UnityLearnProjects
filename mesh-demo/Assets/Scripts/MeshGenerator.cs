using System;
using System.Collections;
using System.Collections.Generic;
using Triangulator;
using UnityEngine;
using UnityEngine.UI;

public enum Turn 
{
    RIGHT,
    LEFT,
    FORWARD,
    BACK,
    NONE
}

public class MeshGenerator : MonoBehaviour
{
    const float WALL_HEIGHT = 3;

    [SerializeField] Material customMat;
    [SerializeField] InputField inputNmbr;
    [SerializeField] Button enterBtn;
    [SerializeField] Toggle[] turnsToggle;

    int wallLenght;
    Vector2 pointStart;
    Vector2 pointEnd;
    bool isWallCreated;    

    Turn wallTurn;
    Turn prevWallTurn;

    void Start()
    {
        pointStart = Vector2.zero;
        enterBtn.interactable = false;
        enterBtn.onClick.AddListener(GenerateNewWall);
        wallTurn = Turn.FORWARD;
    }

    private void Update()
    {
        _ = Int32.TryParse(inputNmbr.text, out wallLenght);

        if (wallLenght != 0)
        {
            enterBtn.interactable = true;
            pointStart = pointEnd;
        }
    }

    public void TurnToggleChanged(Toggle toggle) 
    {
        wallTurn = toggle.GetComponent<ToggleData>().TurnState;
    }

    void GenerateNewWall()
    {
        switch (wallTurn)
        {
            case Turn.RIGHT:
                if (prevWallTurn != Turn.LEFT)
                    pointEnd = pointStart + new Vector2(wallLenght, 0);
                else
                    wallTurn = Turn.NONE;
                break;
            case Turn.LEFT:
                if (prevWallTurn != Turn.RIGHT)
                    pointEnd = pointStart + new Vector2(wallLenght * -1, 0);
                else
                    wallTurn = Turn.NONE;
                break;
            case Turn.FORWARD:
                if (prevWallTurn != Turn.BACK)
                    pointEnd = pointStart + new Vector2(0, wallLenght);
                else
                    wallTurn = Turn.NONE;
                break;
            case Turn.BACK:
                if (prevWallTurn != Turn.FORWARD)
                    pointEnd = pointStart + new Vector2(0, wallLenght * -1);
                else
                    wallTurn = Turn.NONE;
                break;
        }

        if (wallTurn != Turn.NONE)
        {
            GenerateWall(pointStart, pointEnd, WALL_HEIGHT);
        }
        else
        {
            Debug.LogWarning("CAN'T CREATE A WALL IN THIS DIRECTION, PLEASE CHOOSE ANOTHER DIRECTION");
        }

        pointStart = pointEnd;
        prevWallTurn = wallTurn;
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
        _go.GetComponent<MeshRenderer>().sharedMaterial = customMat;
    }
}
