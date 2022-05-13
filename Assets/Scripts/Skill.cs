using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region test
    public int centerX, centerY;
    public int damageWidth, damageHeight;
    public AgentBase targetAgent;
    #endregion

    public int[,] GenerateRectHPChangeMap(
        int centerX, int centerY,
        int damageWidth, int damageHeight,
        int targetAgentMapWidth, int targetAgentMapHeight)
    {

        int[,] result;
        result = new int[targetAgentMapWidth, targetAgentMapHeight];
        for (int i = centerX - damageWidth / 2; i <= centerX + damageWidth / 2; i++)
        {
            for (int j = centerY - damageHeight / 2; j <= centerY + damageHeight / 2; j++)
            {
                if (i >= 0 && i < targetAgentMapWidth && j >= 0 && j < targetAgentMapHeight)
                {
                    result[i, j] = 1;
                }
            }
        }
        return result;
    }

    public void RectDamageInEditor(AgentBase target)
    {
        target.ChangeHP(GenerateRectHPChangeMap(centerX, centerY, damageWidth, damageHeight, target.agentData.bodyMap.GetLength(0), target.agentData.bodyMap.GetLength(1)));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
