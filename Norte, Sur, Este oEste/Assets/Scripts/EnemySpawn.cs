using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public GameObject clone;

    public float difficulty = 0.05f;

    public int enemyType;

    public float min = 1.05f;
    public float max = 3.05f;
    public float generatorTimer;

    public Vector2[] directions = { new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), new Vector2(-1.0f, 0.0f) };
    public Vector2 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Generate()
    {
        AumentDifficulty();

        enemyType = Random.Range(0, 3);
        generatorTimer = Random.Range(min, max);
        direction = directions[Random.Range(0, 3)];

        //Modificar esto acorde a direcciones y velocidades
        clone = Instantiate(enemyPrefabs[enemyType], transform.position, Quaternion.identity);
        clone.transform.position = new Vector3(direction.x * 0.2f, direction.y * 0.2f, 0f);
        Rigidbody2D cloneBody = clone.GetComponent<Rigidbody2D>();
        cloneBody.velocity.Set(direction.x, direction.y);
        clone.SendMessage("SetSprite", direction);

        InvokeRepeating("Generate", 0f, generatorTimer);
    }

    public void AumentDifficulty() {
        if (min > 0.0f) {
            min -= difficulty;
            max -= difficulty;
        }
    }

    public void StopGenerate() {
        CancelInvoke("Generate");
    }
}
