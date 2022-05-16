using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "agent", menuName = "AgentData/Agent")]
public class AgentData : ScriptableObject
{
    public Module[] modules;
    
    public PixelData[,] bodyMap;//TODO: Switch to PixelData[]

    public void SetBodyMap(int length, int width)
    {
        if (length > 0 && width > 0)
        {
            bodyMap = new PixelData[length, width];
        }
    }

    public void GenerateRandomMapData()
    {
        if (bodyMap != null)
        {
            for (int i = 0; i < bodyMap.GetLength(0); i++)
            {
                for (int j = 0; j < bodyMap.GetLength(1); j++)
                {
                    bodyMap[i, j] = new PixelData(Random.Range(1, 100));
                }
            }
        }
    }
}
