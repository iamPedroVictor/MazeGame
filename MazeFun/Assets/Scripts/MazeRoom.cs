using UnityEngine;
using System.Collections.Generic;

public class MazeRoom : ScriptableObject {

	public int settingsIndex;

	public MazeRoomSettings settings;

	public List<MazeCell> cells = new List<MazeCell>();

    public int boxDisponiveis = 0;


	public void Add (MazeCell cell) {
		cell.room = this;
		cells.Add(cell);
	}

    public bool cellDisponiveis() {
        if (cells.Count < this.settings.Minimo) return true;
        return false;
    }

	public void Assimilate (MazeRoom room){
		for (int i = 0; i < room.cells.Count; i++) {
			Add (room.cells [i]);
		}
	}

    public void Hide()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Hide();
        }
    }

    public void Show()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].Show();
            settings.visto = true;
        }
    }
}