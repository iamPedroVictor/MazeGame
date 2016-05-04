using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour {
	public IntVector2 coordinates;

    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];
    private GameObject CameraM;

	public MazeCellEdge GetEdge (MazeDirection direction) {
		return edges[(int)direction];
	}

    public void Show()
    {
        gameObject.SetActive(true);
        if (CameraM != null) {
            if (!CameraM.GetComponent<CameraMap>().verifyListQuartos(this)) {
                CameraM.GetComponent<CameraMap>().addListCell(this);
            }
        }

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnPlayerEntered()
    {
        room.Show();
        for (int i = 0; i < edges.Length; i++)
        {
            edges[i].OnPlayerEntered();
        }
    }

    public void OnPlayerExited()
    {
        room.Hide();
        for (int i = 0; i < edges.Length; i++)
        {
            edges[i].OnPlayerExited();
        }
    }

    private int initializedEdgeCount;

	public MazeRoom room;



    public void Initialize (MazeRoom room) {
		room.Add(this);
		transform.GetChild(0).GetComponent<Renderer>().material = room.settings.floorMaterial;
        int chance = Random.Range(0, 100);
        CameraM = GameObject.Find("CameraMap");
    }

	public bool IsFullyInitialized {
		get {
			return initializedEdgeCount == MazeDirections.Count;
		}
	}

	public void SetEdge (MazeDirection direction, MazeCellEdge edge) {
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}

	public MazeDirection RandomUninitializedDirection {
		get {
			int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++) {
				if (edges[i] == null) {
					if (skips == 0) {
						return (MazeDirection)i;
					}
					skips -= 1;
				}
			}
			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}
}
