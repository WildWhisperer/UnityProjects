using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonGeneration : MonoBehaviour {

	public GameObject prefab;
	public GameObject player;

	int tileSize = 1 ;

	public int maxTiles;
	[HideInInspector]
	public int tileCount;

	Vector3 tilePosition,tempPosition;
    public List<Vector3> position = new List<Vector3>();

	//roomDirectionMin and roomDirectionMax are the variables put in a random range to choose between 0-11,The numbers choosen determine the direction of the room
	//directionMin and directionMax are the variables put in a random range to choose between 0-4,The numbers choosen determine the direction of the tile and 4 means the arena can have rooms
	//minRoomSize and maxRoomSize detetermine the minimum and maximum size of the room that can occur
	public float directionMin,directionMax;
	int Direction;

	public int roomDirectionMin,roomDirectionMax;
	public int minRoomSize,maxRoomSize;
	int roomSize,roomDirection;

	//Vectors used to calculate midpoint and then move the grid there
	public Vector3 midPoint;
	Vector3 upRight,downLeft;

	public List<GameObject> tiles = new List<GameObject>();

	void Start () 
	{
		Instantiate (prefab,tilePosition,Quaternion.identity);
		position.Add (tilePosition);
		Instantiate(player,tilePosition,Quaternion.identity);

		while (tileCount < maxTiles)
		{
			Direction = Mathf.RoundToInt( Random.Range(directionMin,directionMax));
			if(Direction == 0)
			{
				tilePosition += new Vector3(tileSize,0,0);
				if(!position.Contains(tilePosition))
				{
					Instantiate (prefab,tilePosition,Quaternion.identity);
					position.Add(tilePosition);
					tileCount++;
				}
			}
			if(Direction == 1)
			{
				tilePosition += new Vector3(-tileSize,0,0);
				if(!position.Contains(tilePosition))
				{
					Instantiate (prefab,tilePosition,Quaternion.identity);
					position.Add(tilePosition);
					tileCount++;
				}
			}
			if(Direction == 2)
			{
				tilePosition += new Vector3(0,tileSize,0);
				if(!position.Contains(tilePosition))
				{
					Instantiate (prefab,tilePosition,Quaternion.identity);
					position.Add(tilePosition);
					tileCount++;
				}
			}
			if(Direction == 3)
			{
				tilePosition += new Vector3(0,-tileSize,0);
				if(!position.Contains(tilePosition))
				{
					Instantiate (prefab,tilePosition,Quaternion.identity);
					position.Add(tilePosition);
					tileCount++;
				}
			}
			
			// generating rooms
			
			if(Direction >= 4)
			{
				tempPosition = tilePosition;

				roomSize = Mathf.RoundToInt(Random.Range(minRoomSize,maxRoomSize));
				roomDirection = Mathf.RoundToInt(Random.Range (roomDirectionMin,roomDirectionMax));

				if(roomDirection == 0)
				{
					for(int y = 0; y < roomSize; y++)
					{

						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}

						tilePosition += new Vector3(0,tileSize,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(tileSize,0,0);
						}
						tilePosition.x -= roomSize;
					}
				}
				if(roomDirection == 1)
				{
					for(int y = 0; y < roomSize; y++)
					{

						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(0,-tileSize,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(tileSize,0,0);

						}
						tilePosition.x -= roomSize;

					}
				}
				if(roomDirection == 2)
				{
					for(int y = 0; y < roomSize; y++)
					{

						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(-tileSize,0,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;

								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(0,tileSize,0);

						}
						tilePosition.y -= roomSize;

					}
				}
			
				if(roomDirection == 3)
				{
					for(int y = 0; y < roomSize; y++)
					{

						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(tileSize,0,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(0,tileSize,0);

						}
						tilePosition.y -= roomSize;

					}
				 }

				if(roomDirection == 4)
				{
					for(int y = 0; y < roomSize; y++)
					{
						
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(0,tileSize,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(-tileSize,0,0);

						}
						tilePosition.x += roomSize;
					}
				}
				if(roomDirection == 5)
				{
					for(int y = 0; y < roomSize; y++)
					{
						
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(0,-tileSize,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(-tileSize,0,0);

						}
						tilePosition.x += roomSize;
						
					}
				}
				if(roomDirection == 6)
				{
					for(int y = 0; y < roomSize; y++)
					{
						
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(-tileSize,0,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(0,-tileSize,0);

						}
						tilePosition.y += roomSize;
						
					}
				}
				
				if(roomDirection == 7)
				{
					for(int y = 0; y < roomSize; y++)
					{
						
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						
						tilePosition += new Vector3(tileSize,0,0);
						for(int x = 0; x < roomSize ; x++)
						{
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add (tilePosition);
							}
							tilePosition += new Vector3(0,-tileSize,0);

						}
						tilePosition.y += roomSize;
						
					}
				}

				if(roomDirection == 8)
				{
					for(int y = 0; y < roomSize; y++)
					{
						tilePosition.x = tempPosition.x;
						tilePosition += new Vector3(0,tileSize,0);
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						for(int x = 0; x < roomSize ; x++)
						{
							tilePosition += new Vector3(tileSize,0,0);
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add(tilePosition);
							}
						}
					}
				}
				if(roomDirection == 9)
				{
					for(int y = 0; y < roomSize; y++)
					{
						tilePosition.y = tempPosition.y;
						tilePosition += new Vector3(-tileSize,0,0);
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						for(int x = 0; x < roomSize ; x++)
						{
							tilePosition += new Vector3(0,tileSize,0);
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add(tilePosition);
							}
						}
					}
				}
				if(roomDirection == 10)
				{
					for(int y = 0; y < roomSize; y++)
					{
						tilePosition.x = tempPosition.x;
						tilePosition += new Vector3(0,-tileSize,0);
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						for(int x = 0; x < roomSize ; x++)
						{
							tilePosition += new Vector3(-tileSize,0,0);
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add(tilePosition);
							}
						}
					}
				}
				if(roomDirection == 11)
				{
					for(int y = 0; y < roomSize; y++)
					{
						tilePosition.y = tempPosition.y;
						tilePosition += new Vector3(tileSize,0,0);
						if(!position.Contains(tilePosition))
						{
							tileCount++;
							Instantiate (prefab,tilePosition,Quaternion.identity);
							position.Add(tilePosition);
						}
						for(int x = 0; x < roomSize ; x++)
						{
							tilePosition += new Vector3(0,-tileSize,0);
							if(!position.Contains(tilePosition))
							{
								tileCount++;
								Instantiate (prefab,tilePosition,Quaternion.identity);
								position.Add(tilePosition);
							}
						}
					}
				}
			}	
		}

		for(int x = 0 ; x < position.Count; x++)
		{
			if(upRight.x < position[x].x)
			{
				upRight.x = position[x].x;
			}
			if(upRight.y < position[x].y)
			{
				upRight.y = position[x].y;
			}
		}

		for(int x = 0 ; x < position.Count; x++)
		{
			if(downLeft.x > position[x].x)
			{
				downLeft.x = position[x].x;
			}
			if(downLeft.y > position[x].y)
			{
				downLeft.y = position[x].y;
			}
		}
		//Changing the color of tiles
		tiles.AddRange(GameObject.FindGameObjectsWithTag("Tile"));
		Color newTileColor = new Color(Random.value,Random.value,Random.value,Random.Range (0.05f,0.25f));
		for(int x = 0 ; x < tiles.Count; x++)
		{
			tiles[x].GetComponent<SpriteRenderer>().color = newTileColor;
		}

		midPoint = new Vector3 ((upRight.x + downLeft.x)/2,(upRight.y + downLeft.y)/2,0);
	}
}
