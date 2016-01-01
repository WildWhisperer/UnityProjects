using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {
	
	public GameObject[] weapons; 
	public Transform gunSpawner;

	public int currentWeapon = 0;
	private int nrWeapons;
	
	void Awake()
	{
		nrWeapons = weapons.Length;
		weapons[0].gameObject.SetActive(true); // Set default gun
		//setting gun as child of gunSpawner
		gunSpawner = transform.GetChild(0);
		weapons[0].transform.position = gunSpawner.transform.position;
		weapons[0].transform.rotation = gunSpawner.transform.rotation;
		weapons[0].transform.parent = gunSpawner.transform;

		weapons[1].transform.position = gunSpawner.transform.position;
		weapons[1].transform.rotation = gunSpawner.transform.rotation;
		weapons[1].transform.parent = gunSpawner.transform;

		weapons[1].gameObject.SetActive(false);
		Debug.LogWarning ("this script is retarded");
	}
	
	void Update () 
	{
		if(gunSpawner == null)
		{
			gunSpawner = transform.GetChild(0);
		}
		if(Input.GetKeyDown("e"))
		{
			weapons[currentWeapon].SetActive(false);
			if(weapons[1]!=null)
			{
				currentWeapon++;
			}
			if(currentWeapon >= nrWeapons)
			{
				currentWeapon = 0;
			}
			weapons[currentWeapon].SetActive(true);
		}

		if(weapons[1].activeSelf==true && weapons[0].activeSelf==true)
		{
			weapons[0].gameObject.SetActive(false);
		}

	}
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Gun" && weapons[currentWeapon].gameObject != other.gameObject )
		{
			Debug.Log("collisionWithGun");
			
			if (Input.GetKeyDown("q"))
			{
				
				if(weapons[1] == null)
				{
					weapons[1]=other.gameObject;
					//setting guns rotation and position to be equal to gunSpawner
					weapons[1].transform.position=gunSpawner.transform.position;
					weapons[1].transform.rotation=gunSpawner.transform.rotation;
					//setting gunSpawner as the parent of the spawned gun and changing layer to Gun
					other.gameObject.transform.parent = gunSpawner.transform;
					other.gameObject.layer=9;
				}
				
				if(weapons[0].activeSelf == true && weapons[1].activeSelf == false)
				{
					//Spawning the current gun as a pickup and deleting it from the array and setting its layer back to pickUP
					GameObject swappedGun = Instantiate(weapons[0],transform.position,Quaternion.identity) as GameObject;
					swappedGun.gameObject.layer=8;
					Destroy(weapons[currentWeapon]);
					//putting the gun in the array 
					weapons[0]=other.gameObject;
					//setting guns rotation and position to be equal to gunSpawner
					weapons[0].transform.position=gunSpawner.transform.position;
					weapons[0].transform.rotation=gunSpawner.transform.rotation;
					//setting gunSpawner as the parent of the spawned gun and changing layer to Gun
					other.gameObject.transform.parent = gunSpawner.transform;
					other.gameObject.layer=9;
					
				}
				
				if(weapons[1].activeSelf == true && weapons[0].activeSelf == false)
				{
					//Spawning the current gun as a pickup and deleting it from the array and setting its layer back to pickUP
					GameObject swappedGun = Instantiate(weapons[1],transform.position,Quaternion.identity) as GameObject;
					swappedGun.gameObject.layer=8;
					Destroy(weapons[currentWeapon]);
					//putting the gun in the array 
					weapons[1]=other.gameObject;
					//setting guns rotation and position to be equal to gunSpawner
					weapons[1].transform.position=gunSpawner.transform.position;
					weapons[1].transform.rotation=gunSpawner.transform.rotation;
					//setting gunSpawner as the parent of the spawned gun and changing layer to Gun
					other.gameObject.transform.parent = gunSpawner.transform;
					other.gameObject.layer=9;
				}
				
			}
			
			
		}
	}
}

