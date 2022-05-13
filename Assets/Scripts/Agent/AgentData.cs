using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PixelData
{
    public float hp;
    public int moduleID;//属于哪个模块

    public PixelData(float hp, int ID)
    {
        this.hp = hp;
        this.moduleID = ID;
    }

    public void ChangeHP(float amount)
    {
        hp = hp + amount >= 0 ? hp + amount : 0;
    }
}

//TODO - 本地储存
[System.Serializable]
public class AgentData
{
    //public int[,] bodyMap;//每一个代表一个像素点，每个像素点有自己的血条，身体之外设置为-1
    public PixelData[,] bodyMap;
    //public Dictionary<string, List<(int, int)>> modules;
    public AgentData()
    {

    }

    public AgentData(int length, int width)
    {
        if (length > 0 && width > 0)
            bodyMap = new PixelData[length, width];
    }

    public void GenerateRandomMap()
    {
        if (bodyMap != null)
        {
            for (int i = 0; i < bodyMap.GetLength(0); i++)
            {
                for (int j = 0; j < bodyMap.GetLength(1); j++)
                {
                    bodyMap[i, j] = new PixelData(Random.Range(1, 100), Random.Range(1, 5));
                }
            }
        }
    }
}
