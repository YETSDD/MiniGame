using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AgentDisplay))]
public class AgentBase : MonoBehaviour
{
    public AgentData agentData;

    public AgentDisplay agentDisplay;

    public delegate void AgentDelegate(AgentData agentData);
    public AgentDelegate OnAgentDataChanged;

    private void Awake()
    {
        OnAgentDataChanged = UpdateDisplay;
        agentDisplay = GetComponent<AgentDisplay>();
    }

    #region Controller

    public void OnRoundPrepare()
    {
        HandleBuffs(RoundStage.Prepare);
    }

    public void OnRoundAct()
    {
        HandleBuffs(RoundStage.Act);
    }

    public void OnRoundSettle()
    {
        HandleBuffs(RoundStage.Settle);
    }

    private void HandleBuffs(RoundStage stage)
    {
        Module[] modules = agentData.modules;
        for (int i = 0; i < modules.Length; i++)
        {
            HandleBuff(modules[i],stage);
        }
    }

    private void HandleBuff(Module module, RoundStage stage)
    {
    }
    public void ChangeHP(int[,] HPChangeMap)
    {
        if (agentData == null)
        {
            return;
        }

        if (HPChangeMap.GetLength(0) != agentData.bodyMap.GetLength(0) || HPChangeMap.GetLength(1) != agentData.bodyMap.GetLength(1))
        {
            return;
        }

        for (int i = 0; i < HPChangeMap.GetLength(0); i++)
        {
            for (int j = 0; j < HPChangeMap.GetLength(1); j++)
            {
                agentData.bodyMap[i, j].ChangeHP(HPChangeMap[i, j]);

                OnAgentDataChanged.Invoke(agentData);
            }
        }
    }

    #endregion

    #region View

    public void UpdateDisplay(AgentData data)
    {
        if (agentDisplay != null)
        {
            agentDisplay.UpdateMap(data);
        }
    }

    #endregion
}
