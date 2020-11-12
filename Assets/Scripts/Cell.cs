using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellType
{
    Water, Land
}

public class Cell : MonoBehaviour
{
    public CellType _cellType { get; private set; }
    public bool IsCheck;

    Color _colorWater = Color.blue;
    Color _colorLand = Color.green;

    public void Generate(CellType type)
    {
        _cellType = type;

        Color color = _colorWater;
        if (type == CellType.Land) color = _colorLand;
        GetComponent<Image>().color = color;
    }
}
