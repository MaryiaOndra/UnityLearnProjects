using System;
using UnityEngine;
using UnityEngine.UI;

namespace WallGenerator
{
    public enum Turn
    {
        RIGHT,
        LEFT,
        FORWARD,
        BACK,
        NONE
    }

    public class ApplicationManager : MonoBehaviour
    {
        const float WALL_HEIGHT = 3;

        [SerializeField] InputField inputNmbr;
        [SerializeField] Button enterBtn;
        [SerializeField] Button floorBtn;

        MeshGenerator meshGenerator;
        int wallLenght;
        Turn wallTurn;
        Turn prevWallTurn;
        Vector2 pointStart;
        Vector2 pointEnd;

        private void Awake()
        {
            meshGenerator = GetComponentInChildren<MeshGenerator>();
        }

        void Start()
        {
            pointStart = Vector2.zero;
            wallTurn = Turn.FORWARD;

            enterBtn.onClick.AddListener(ConvertInputNbr);
            enterBtn.onClick.AddListener(GenerateNewWall);
            floorBtn.onClick.AddListener(meshGenerator.CreateFloor);
        }

        void ConvertInputNbr()
        {
            Int32.TryParse(inputNmbr.text, out wallLenght);
        }

        void GenerateNewWall()
        {
            SetEndPointPos();

            if (wallTurn != Turn.NONE && wallLenght != 0)
            {
                meshGenerator.CreateWallMesh(pointStart, pointEnd, WALL_HEIGHT);
            }
            else if (wallLenght == 0)
            {
                Debug.LogWarning("WALL LENGTH CAN'T BE '0', CHANGE THE LENGTH");
            }
            else
            {
                Debug.LogWarning("CAN'T CREATE A WALL IN THIS DIRECTION, CHOOSE ANOTHER DIRECTION");
            }

            pointStart = pointEnd;
            prevWallTurn = wallTurn;
        }

        void SetEndPointPos()
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
        }

        public void TurnToggleChanged(Toggle toggle)
        {
            wallTurn = toggle.GetComponent<ToggleData>().TurnState;
        }
    }
}
