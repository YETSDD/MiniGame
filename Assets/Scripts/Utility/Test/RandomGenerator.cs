using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    public class RandomGenerator : MonoBehaviour
    {
        public static GameObject GenerateRandomAgent(GameObject agentPrefab, Transform parent)
        {
            var result = Instantiate(agentPrefab, parent);

            AgentBase rand = result.GetComponent<AgentBase>();
            rand.agentData = ScriptableObject.CreateInstance<AgentData>();
            rand.agentData.SetBodyMap(Random.Range(10, 30), Random.Range(20, 30));
            rand.agentData.GenerateRandomMapData();

            Debug.Log("size:" + rand.agentData.bodyMap.GetLength(0) + "," + rand.agentData.bodyMap.GetLength(1));

            return result;
        }
    }
}
