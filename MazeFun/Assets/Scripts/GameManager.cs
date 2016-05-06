using UnityEngine;
using System.Collections;
using Fungus;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    public Maze mazePrefab;

    public Maze mazeInstance;

	public Player playerPrefab;

	private Player playerInstance;

    private GameObject pRepresentation;

    public GameObject[] tesourosArray;
    private bool okPl = true;

    public Flowchart flowChart;

    public GameObject imageCanvas;

    private void Start () {
		StartCoroutine(BeginGame());
	}

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

	private IEnumerator BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
               
        while (okPl) {
            okPlayer(mazeInstance.RandomCoordinates);
        }
        Debug.Log("Player ok");
        roomWith1Cell();
        pRepresentation = Instantiate(playerInstance.representation) as GameObject;
        pRepresentation.transform.position = new Vector3(playerInstance.transform.position.x, playerInstance.transform.position.z + 10, playerInstance.transform.position.z);
        flowChart.SetBooleanVariable("StartGame", true);
        imageCanvas.SetActive(false);
        flowChart.SendFungusMessage("PlayerOK");

	}

    private void roomWith1Cell() {
        for (int i = 0; i < mazeInstance.rooms.Count; i++) {
            if (mazeInstance.rooms[i].cells.Count < 2){
                Debug.Log("Quarto de 1 celula");
            }else if (mazeInstance.rooms[i].cells.Count == 2){
                Debug.Log("Quarto de 2 celula");
            }else {
                Debug.Log("Quarto com: " + mazeInstance.rooms[i].cells.Count);
            }
        }
    }

    private void okPlayer(IntVector2 intV2) {
        if (mazeInstance.GetCell(intV2).room.cells.Count > 6)
        {
            playerInstance = Instantiate(playerPrefab) as Player;
            playerInstance.SetLocation(mazeInstance.GetCell(intV2));
            okPl = false;
        }else {
            Debug.Log("Player não ok");
            return;
        }
    }

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}

    public void NotaAdd() {
        flowChart.SetIntegerVariable("Notas", flowChart.GetIntegerVariable("Notas")+1);
        flowChart.SendFungusMessage("NotaAdicionada");
    }

}
