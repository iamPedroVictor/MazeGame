using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Maze mazePrefab;

	private Maze mazeInstance;

	public Player playerPrefab;

	private Player playerInstance;

    private GameObject pRepresentation;

    public GameObject[] tesourosArray;

	private void Start () {
		StartCoroutine(BeginGame());
	}

	private IEnumerator BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate());
        Debug.Log(tesourosArray.Length);
        for (int i = 0; i < tesourosArray.Length; i++)
        {
            GameObject tesouroInstance = Instantiate(tesourosArray[i]) as GameObject;
            //IntVector2 positionCell = ;
            tesouroInstance.GetComponent<Tesouro>().SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

        }
        playerInstance = Instantiate(playerPrefab) as Player;
		playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        pRepresentation = Instantiate(playerInstance.representation) as GameObject;
        pRepresentation.transform.position = new Vector3(playerInstance.transform.position.x, playerInstance.transform.position.z + 10, playerInstance.transform.position.z);

	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		StartCoroutine(BeginGame());
	}
}
