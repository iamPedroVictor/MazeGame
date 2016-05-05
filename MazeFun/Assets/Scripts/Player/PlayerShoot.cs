using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public float range;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
	
	}

    void Shoot() {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range, mask))
        {
            Debug.Log("Hit: " + _hit.collider.name);
            if (_hit.collider.tag == "Porta") {
                if (_hit.collider.GetComponent<MazeDoor>().cell == GetComponent<Player>().currentCell) {
                    GetComponent<Player>().currentCell.coordinates = _hit.collider.GetComponent<MazeDoor>().cell.coordinates;
                }

            }
        }
    }
}
