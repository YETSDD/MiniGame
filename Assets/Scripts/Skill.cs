using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region EditorParam
    public int centerX, centerY;

    public int damageWidth, damageHeight;

    public AgentBase targetAgent;
    #endregion

    public int[,] GenerateRectHPChangeMap(
        int centerX, int centerY,
        int damageWidth, int damageHeight,
        int targetAgentMapWidth, int targetAgentMapHeight)
    {
        int[,] result = new int[targetAgentMapWidth, targetAgentMapHeight];

        for (int i = centerX - damageWidth / 2; i <= centerX + damageWidth / 2; i++)
        {
            for (int j = centerY - damageHeight / 2; j <= centerY + damageHeight / 2; j++)
            {
                if (i >= 0 && i < targetAgentMapWidth && j >= 0 && j < targetAgentMapHeight)
                {
                    result[i, j] = -10;
                }
            }
        }
        return result;
    }

    public void RectDamageToAgent()
    {
        int[,] rectChangeMap = GenerateRectHPChangeMap(centerX, centerY,
                    damageWidth, damageHeight,
                    targetAgent.agentData.bodyMap.GetLength(0), targetAgent.agentData.bodyMap.GetLength(1));

        targetAgent.ChangeHP(rectChangeMap);
    }
}
