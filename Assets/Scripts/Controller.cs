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
                int dice = Random.Range(0, 2);
                CellType type;
                if (cells[x, y] == null)
                    Cell cell = Instantiate(_cellPref, _field, false).GetComponent<Cell>();
                    
            }
    }
}
