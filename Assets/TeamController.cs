using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {
    public int team;
    public string offense;
    public string defense;
    public float [,,] grid= new float[27,15,2];
	void Start () {
        initializeGrid();
	}

    public void initializeGrid()
    {
        float x = -7.5f;
        float y = -13.5f;
        for (int i=0; i<27; i++)
        {
            for (int j=0; j<15; j++)
            {
                grid[i, j, 0] = x;
                grid[i, j, 1] = y;
                x += 1;
            }
            y += 1;
        }
    }
	
	void Update () {
		
	}
}
