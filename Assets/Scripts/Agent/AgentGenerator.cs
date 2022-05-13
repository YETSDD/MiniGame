using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGenerator : MonoBehaviour
{
    public GameObject AgentPrefab;

    public GameObject grid;
    public static float gridLength = 1.1f;
    public static float gridWidth = 1.1f;
    List<GameObject> grids = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMap(AgentData src, Transform root)
    {
        PixelData[,] map = src.bodyMap;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                var obj = Instantiate(grid, new Vector3(i * gridWidth, j * gridLength, 0), Quaternion.identity, root);
                grids.Add(obj);
                Color color = new Color(Mathf.Lerp(0, 1, src.bodyMap[i, j].hp / 100.0f), 0, 0, 1);
                Debug.Log(src.bodyMap[i, j].hp + " " + color);
                obj.GetComponent<Renderer>().material.color = color;
            }
        }
    }
    public void DestroyMap()
    {
        //TODO
    }

    #region test
    public GameObject currentAgent;
    public void ShowRandomBodyMap()
    {
        var temp = GenerateRandomAgent();
        currentAgent = temp;
        ShowMap(temp.GetComponent<AgentBase>().agentData, temp.transform);
    }
    public GameObject GenerateRandomAgent()
    {
        var result = Instantiate(AgentPrefab, this.transform);
        AgentBase rand = result.GetComponent<AgentBase>();
        rand.agentData = new AgentData(Random.Range(10, 30), Random.Range(20, 30));
        rand.agentData.GenerateRandomMap();
        Debug.Log("size:" + rand.agentData.bodyMap.GetLength(0) + "," + rand.agentData.bodyMap.GetLength(1));
        return result;
    }

    //public void DestroyGrids() {
    //    for (int i = grids.Count; i >= 0; i--) { 
    //        Destroy(grids[i]);
    //        grids.RemoveAt(i);
    //    }
    //}

    public void DestroyAgentInEditor()
    {
        if (currentAgent != null)
        {
            DestroyImmediate(currentAgent);
        }
    }
    #endregion
}
