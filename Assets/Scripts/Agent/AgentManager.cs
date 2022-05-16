using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject agentPrefab;
    
    public GameObject playerAgentObject;

    public void UpdateAgentMap(GameObject target) {
        AgentBase agentBase = target.GetComponent<AgentBase>();
        AgentDisplay agentDisplay;
        if (target.TryGetComponent<AgentDisplay>(out agentDisplay)) {
            agentDisplay.UpdateMap(agentBase.agentData);
        }
    }
}
