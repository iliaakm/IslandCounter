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

    Cell[,] _cells = new Cell[n, m];
    void GenerateField(Cell[,] cells)
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
                cells[x, y] = cell;
            }
        print("Generate done");
    }

    public void GenerateField()
    {
        GenerateField(_cells);
    }

    void CountIslands(Cell[,] cells)
    {
        int islandCounter = 0;

        for (int x = 0; x < n; x++)
            for (int y = 0; y < m; y++)
            {
                Cell cell = cells[x, y];
                if (cell == null) continue;
                if (cell.IsCheck || cell._cellType == CellType.Water) continue;         //проверка
                if (cell._cellType == CellType.Land)
                {
                    islandCounter++;
                    CheckCell(cells, x, y);
                }
            }

        print("ISLANDS = " + islandCounter);
    }

    public void CountIslands()
    {
        CountIslands(_cells);
    }

    void CheckCell(Cell[,] cells, int x, int y)
    {
        if (x < 0 || y < 0) return;
        if (x >= n || y >= m) return;

        if (cells[x, y].IsCheck || cells[x, y]._cellType == CellType.Water) return;    //проверка на повтор и воду
        cells[x, y].Check();
        CheckCell(cells, x - 1, y);     //слева
        CheckCell(cells, x + 1, y);     //справа
        CheckCell(cells, x, y + 1);     //сверху
        CheckCell(cells, x, y - 1);     //снизу
    }
}
