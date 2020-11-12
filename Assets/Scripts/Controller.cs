using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    const int n = 160;
    const int m = 100;

    [SerializeField]
    Transform _field;
    [SerializeField]
    GameObject _cellPref;

    Cell[,] cells = new Cell[n, m];
    public void GenerateField()
    {
        for (int x = 0; x < n; x++)
            for (int y = 0; y < m; y++)
            {
                Cell cell;
                if (cells[x, y] != null) cell = cells[x, y];
                else
                    cell = Instantiate(_cellPref, _field, false).GetComponent<Cell>();

                int dice = Random.Range(0, 2);
                CellType type = (dice == 0) ? CellType.Land : CellType.Water;       // 0 - суша, 1 - вода
                cell.Generate(type);
            }
    }
}
