using UnityEngine;
using System.Collections.Generic;

public class CameraMap : MonoBehaviour {

    //public bool activeCamera { get; set; }
    public Transform[] objectsArray = new Transform[3];
    public GameObject[] spriteArray = new GameObject[3];

    public List<MazeCell> quartosVistos = new List<MazeCell>();

    public void addListCell(MazeCell cell) {
        quartosVistos.Add(cell);
    }

    public bool verifyListQuartos(MazeCell cell) {
        if (quartosVistos.Contains(cell)){
            return true;
        }
        return false;
    }

    public void startArray() {
        objectsArray[0] = GameObject.FindGameObjectWithTag("Player").transform;
        spriteArray[0] = GameObject.FindGameObjectWithTag("PlayerR");
    }

    public void DontViewMap() {
        for (int i = 0; i < spriteArray.Length; i++)
        {
            if(spriteArray[i]!=null)
                spriteArray[i].SetActive(false);
        }
        for (int y = 0; y < quartosVistos.Count - 1; y++){
            quartosVistos[y].Hide();
        }
    }

    public void ViewMap() {
        if(spriteArray[0] == null)
            spriteArray[0] = GameObject.FindGameObjectWithTag("PlayerR");
        for (int i = 0; i < objectsArray.Length; i++) {
            if (spriteArray[i] != null && objectsArray[i] != null){
                spriteArray[i].transform.position = objectsArray[i].position;
                spriteArray[i].SetActive(true);
            }
        }
        for (int y = 0; y < quartosVistos.Count - 1; y++) {
            quartosVistos[y].Show();
        }

    }

}
