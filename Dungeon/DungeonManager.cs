using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonManager : MonoBehaviour {
	public bool canDeleteItSelf;
	public GameObject wall;
	public bool canGenerateWalls = true;
	
	public DungeonManager dungeonManager;
	public DungeonGeneration dungeonGeneration;


	public static List<Vector3> wallPosition = new List<Vector3>();

	Vector3 pos;
	void Start () 
	{
		dungeonManager = GetComponent<DungeonManager>();
		dungeonGeneration = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DungeonGeneration>();
		
	}
	
	void FixedUpdate () 
	{
		if(dungeonGeneration.tileCount >= dungeonGeneration.maxTiles && canGenerateWalls == true)
		{
			Invoke("GenerateWalls",0f);
			DisablingScript ();
			canGenerateWalls = false;
		}
	}

	public void GenerateWalls()
	{
		pos = transform.position + new Vector3 (-1,0,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}

		pos = transform.position + new Vector3 (1,0,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}
	
		pos = transform.position + new Vector3 (0,1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}

		pos = transform.position + new Vector3 (0,-1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}

		pos = transform.position + new Vector3 (-1,-1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}
		
		pos = transform.position + new Vector3 (1,-1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}

		pos = transform.position + new Vector3 (1,1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}

		pos = transform.position + new Vector3 (-1,1,0);
		if(!wallPosition.Contains (pos) && !dungeonGeneration.position.Contains(pos))
		{
			Instantiate(wall,pos,transform.rotation);	
			wallPosition.Add (pos);
		}
		
	}
	public void DisablingScript()
	{
		if(canDeleteItSelf)
		{
			dungeonManager.enabled=false;
		}
	}
}



