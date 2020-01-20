using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour {
    public int team;
    private bool possession;
    public string play;
    public float [,,] grid= new float[27,15,2];
    public GameObject pg, sg, sf, pf, c;
    private GameObject dpg, dsg, dsf, dpf, dc, dgoal;
    public Vector3[] spots = new Vector3[10];
    public GameObject[] direction= new GameObject[5];
    private Ball ball;

    void Start () {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
        initializeGrid();
        initializeTeam();
        initializeD();
        initializeDirections();
        run(play);
    }
    private void initializeD()
    {
        if (team % 2 == 1)
        {
            dpg = GameObject.Find("PG0");
            dsg = GameObject.Find("SG0");
            dsf = GameObject.Find("SF0");
            dpf = GameObject.Find("PF0");
            dc = GameObject.Find("C0");
            dgoal = GameObject.Find("Goal0");
        }
        else
        {
            dpg = GameObject.Find("PG1");
            dsg = GameObject.Find("SG1");
            dsf = GameObject.Find("SF1");
            dpf = GameObject.Find("PF1");
            dc = GameObject.Find("C1");
            dgoal = GameObject.Find("Goal1");
        }
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
        pg = GameObject.Find("PG"+team);
        sg = GameObject.Find("SG"+team);
        sf = GameObject.Find("SF"+team);
        pf = GameObject.Find("PF"+team);
        c = GameObject.Find("C"+team);
    }

    private void motion4out(bool high)
    {
        if (team==0)
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
                GameObject.Find(team.ToString() + (i + 1).ToString()).GetComponent<Thing>().Adjust(spots[i].x, spots[i].z);
            }
        }
        else
        {
            if (spots[0].y == 0f)
            {
                spots[0] = new Vector3(grid[8, 5, 0]*-1, -.4f, grid[8, 5, 1]*-1);
                spots[1] = new Vector3(grid[8, 10, 0]*-1, -.4f, grid[8, 10, 1]*-1);
                spots[2] = new Vector3(grid[4, 1, 0]*-1, -.4f, grid[4, 1, 1]*-1);
                spots[3] = new Vector3(grid[4, 14, 0]*-1, -.4f, grid[4, 14, 1]*-1);
                if (high)
                    spots[4] = new Vector3(grid[5, 7, 0]*-1, -.4f, grid[5, 7, 1]*-1);
                else
                    spots[4] = new Vector3(grid[2, 6, 0]*-1, -.4f, grid[2, 6, 1]*-1);
                spots[5] = new Vector3(grid[0, 7, 0]*-1, -.4f, grid[0, 7, 1]*-1);
            }
            for (int i = 0; i < 5; i++)
            {
                print(team.ToString() + (i + 1).ToString());
                GameObject.Find(team.ToString() + (i + 1).ToString()).GetComponent<Thing>().Adjust(spots[i].x, spots[i].z);
            }
        }
    }

    private void run(string play)
    {
        if (play == "motion4out")
        {
            motion4out(true);
        }
    }
	void FixedUpdate () {
        if(ball.teamPossession!=team)//if on defense
        {
            direction[0].transform.position = Vector3.Lerp(dpg.transform.position, dgoal.transform.position, .3f);
            direction[1].transform.position = Vector3.Lerp(dsg.transform.position, dgoal.transform.position, .3f);
            direction[2].transform.position = Vector3.Lerp(dsf.transform.position, dgoal.transform.position, .3f);
            direction[3].transform.position = Vector3.Lerp(dpf.transform.position, dgoal.transform.position, .3f);
            direction[4].transform.position = Vector3.Lerp(dc.transform.position, dgoal.transform.position, .3f);
        }
        else
        {
            direction[0].transform.position = spots[0];
            direction[1].transform.position = spots[1];
            direction[2].transform.position = spots[2];
            direction[3].transform.position = spots[3];
            direction[4].transform.position = spots[4];
        }
	}
}
