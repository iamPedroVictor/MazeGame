using UnityEngine;

public class Player : MonoBehaviour {

	public MazeCell currentCell;

    public GameObject camMain;
    public GameObject camMap;
    public GameObject representation;

    private MazeDirection currentDirection;

    private void Rotate(MazeDirection direction)
    {
        transform.localRotation = direction.ToRotation();
        currentDirection = direction;
    }


    public void SetLocation (MazeCell cell) {
        if (currentCell != null){
            currentCell.OnPlayerExited();
        }
        currentCell = cell;
		transform.localPosition = new Vector3(cell.transform.localPosition.x - 0.5f, cell.transform.localPosition.y + 1f, cell.transform.localPosition.z - 0.5f);
        currentCell.OnPlayerEntered();
      //  camMap = GameObject.Find("CameraMap");
      //  camMap.SetActive(false);
        //camMain.SetActive(true);


    }

	private void Move (MazeDirection direction) {
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage) {
			SetLocation(edge.otherCell);
		}
	}

    private void Awake() {
        if (camMap == null)
            camMap = GameObject.Find("CameraMap");
        camMap.SetActive(false);
        camMain.SetActive(true);
    }

    private void Start() {
        camMap.GetComponent<CameraMap>().startArray();
    }

	private void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)){
            camMain.SetActive(!camMain.activeInHierarchy);
            camMap.SetActive(!camMap.activeInHierarchy);
            if (camMap.activeInHierarchy){
                camMap.GetComponent<CameraMap>().ViewMap();
            }else {
                camMap.GetComponent<CameraMap>().DontViewMap();
            }
        }

        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            Move(currentDirection);
        }else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            Move(currentDirection.GetNextClockwise());
        }else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            Move(currentDirection.GetOpposite());
        }else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            Move(currentDirection.GetNextCounterclockwise());
        }else if (Input.GetKeyDown(KeyCode.Q)){
            Rotate(currentDirection.GetNextCounterclockwise());
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            Rotate(currentDirection.GetNextClockwise());
        }
    }
}