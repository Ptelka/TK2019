using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{
	[SerializeField] int MaxCables = 2;
	private int player1cables = 0;
	private int player2cables = 0;

    private static GameControll instance;
    public static GameControll Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    public void OnCable(int player)
	{
		if (player == 1)
		{
			player1cables++;
			
			if (MaxCables < player1cables)
			{
				
			}
		}
		else
		{
			player2cables++;

			if (MaxCables < player2cables)
			{
				
			}
		}
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame(Team winners)
    {
        Debug.Log("winners_" + winners.ToString());
        //SceneManager.LoadScene("winners_" + winners.ToString());
    }
}

public enum Team
{
    Topornicy,
    Wlocznicy
}
