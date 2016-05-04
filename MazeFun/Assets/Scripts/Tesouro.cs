using UnityEngine;
using System.Collections;

public class Tesouro : MonoBehaviour {

    private MazeCell currentCell;

    public void SetLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }

}
