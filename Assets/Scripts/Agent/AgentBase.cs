using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBase : MonoBehaviour
{
    public AgentData agentData;

    #region Controller
    public void ChangeHP(int[,] HPChangeMap)
    {
        if (agentData == null)
            return;
        if (HPChangeMap.GetLength(0) != agentData.bodyMap.GetLength(0) || HPChangeMap.GetLength(1) != agentData.bodyMap.GetLength(1))
            return;

        for (int i = 0; i < HPChangeMap.GetLength(0); i++)
        {
            for (int j = 0; j < HPChangeMap.GetLength(1); j++)
            {
                agentData.bodyMap[i, j].ChangeHP(HPChangeMap[i, j]);
            }
        }
    }

    #endregion 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
