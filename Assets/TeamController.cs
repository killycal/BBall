using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {
    public int team;
    private bool possession;
    public string play;
    public float [,,] grid= new float[27,15,2];
    public GameObject pg, sg, sf, pf, c;
    public Vector3[] spots = new Vector3[10];
    public GameObject[] direction= new GameObject[5];

    void Start () {
        initializeGrid();
        initializeTeam();
        initializeDirections();
        if (play == "motion4out")
        {
            motion4out(false);
        }
        motion4out(false);
    }
    private void initializeDirections()
    {
        direction[0] = GameObject.Find(team.ToString() + 1);
        direction[1] = GameObject.Find(team.ToString() + 2);
        direction[2] = GameObject.Find(team.ToString() + 3);
        direction[3] = GameObject.Find(team.ToString() + 4);
        direction[4] = GameObject.Find(team.ToString() + 5);
    } 
    private void initializeGrid()
    {
        float y = 7f;
        float x = -13f;
        for (int i=0; i<27; i++)
        {
            y = 7f;
            for (int j=0; j<15; j++)
            {
                grid[i, j, 0] = x;
                grid[i, j, 1] = y;
                y -= 1;
            }
            x += 1;
        }
    }

    private void initializeTeam()
    {
        pg = GameObject.Find(team + "1");
        sg = GameObject.Find(team + "2");
        sf = GameObject.Find(team + "3");
        pf = GameObject.Find(team + "4");
        c = GameObject.Find(team + "5");
    }

    private void motion4out(bool high)
    {
        if (spots[0].y == 0f)
        {
            spots[0] = new Vector3(grid[8, 5, 0], -.4f, grid[8, 5, 1]);
            spots[1] = new Vector3(grid[8, 10, 0], -.4f, grid[8, 10, 1]);
            spots[2] = new Vector3(grid[4, 1, 0], -.4f, grid[4, 1, 1]);
            spots[3] = new Vector3(grid[4, 14, 0], -.4f, grid[4, 14, 1]);
            if (high)
                spots[4] = new Vector3(grid[5, 7, 0], -.4f, grid[5, 7, 1]); 
            else
                spots[4] = new Vector3(grid[2, 6, 0], -.4f, grid[2, 6, 1]);
            spots[5] = new Vector3(grid[0, 7, 0], -.4f, grid[0, 7, 1]);
        }
        for (int i = 0; i < 5; i++)
        {
            print(team.ToString() + (i + 1).ToString());
            GameObject.Find(team.ToString()+(i+1).ToString()).GetComponent<Thing>().Adjust(spots[i].x, spots[i].z);
        }
    }

    private void run(string play)
    {
        if (play == "motion4out")
        {
            motion4out(false);
        }
    }
	void Update () {
	}
}
