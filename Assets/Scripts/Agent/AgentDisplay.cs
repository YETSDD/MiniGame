using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DisplayMode
{
    Normal = 0,
    BlackAndWhite = 1, //血条展示
    ElementColor = 2 //血条+元素展示

}

public class AgentDisplay : MonoBehaviour
{
    public DisplayMode displayMode = DisplayMode.ElementColor;

    public GameObject gridPrefab;

    public const float gridLength = 1.1f;

    public const float gridWidth = 1.1f;

    private GameObject[,] _grids;

    public void InitializeMap(AgentData src, Transform root, DisplayMode mode = DisplayMode.ElementColor)
    {
        PixelData[,] map = src.bodyMap;
        _grids = new GameObject[src.bodyMap.GetLength(0), src.bodyMap.GetLength(1)];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(i * gridWidth, j * gridLength, 0), Quaternion.identity, root);

                _grids[i, j] = obj;
            }
        }
    }

    private Color GetPixelColor(float healthPoint, DisplayMode mode)
    {
        float colorVal = Mathf.Lerp(0, 1, healthPoint / 100.0f);
        Color color;
        switch (mode)
        {
            case DisplayMode.BlackAndWhite:
                color = Color.HSVToRGB(0, 1, Mathf.Lerp(0, 1, colorVal));
                break;
            case DisplayMode.ElementColor://TODO: Different Element Color 
                color = new Color(colorVal, 0, 0, 1);
                break;
            default:
                color = new Color(1, 1, 1);
                break;
        }

        return color;
    }

    public void UpdateMap(AgentData src, DisplayMode mode = DisplayMode.ElementColor)
    {
        if (_grids == null)
        {
            return;
        }

        PixelData[,] map = src.bodyMap;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                float healthPoint = src.bodyMap[i, j].currentHealthPoint;
                Color color = GetPixelColor(healthPoint, mode);

                _grids[i, j].GetComponent<Renderer>().material.color = color;
            }
        }
    }
}
