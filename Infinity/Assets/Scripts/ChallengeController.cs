using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {

	public float scrollSpeed = 5.0f;

	public GameObject[] challenges;

	public float frequency = 0.5f;

	float counter = 0.0f;

	public Transform challengesSpawnPoint;
	GameObject currentChild;
	// Use this for initialization
	void Start () {
		GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {

		//Generate Objects()
		if (counter <= 0.0f)
		{
			GenerateRandomChallenge();
		}
		else{
			counter -= Time.deltaTime * frequency;
		}
		
		//Scrolling
		
		for (int i = 0; i < transform.childCount; i++)
		{
			currentChild = transform.GetChild(i).gameObject;
			ScrollChallenge(currentChild);

			// destroying the object when it goes out the screen
			if (currentChild.transform.position.x <= -15.0f)
			{
				Destroy(currentChild);
			}
		}
	}

	// to move the object towards the player
	void ScrollChallenge (GameObject currentChallenge){

		currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);

	}

	void GenerateRandomChallenge()
	{
		GameObject newChallenge =  Instantiate (challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position,Quaternion.identity) as GameObject;
		newChallenge.transform.parent = transform;
		counter = 1.0f;
	}
}
