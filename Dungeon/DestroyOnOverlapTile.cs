using UnityEngine;
using System.Collections;

public class DestroyOnOverlapTile : MonoBehaviour {

	public DungeonGeneration dungeonGeneration;

	void Start()
	{
		dungeonGeneration = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DungeonGeneration>();
		if(dungeonGeneration.position.Contains(transform.position))
		{
			Destroy (gameObject);
		}
	}
}