using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemyPrefabs;
    public GameObject clone;

    public float difficulty = 0.025f;

    public int enemyType;

    private float min;
    private float max;
    public float generatorTimer;

    public Vector2[] directions = { new Vector2(0.0f, 1.0f), new Vector2(1.0f, 0.0f), new Vector2(0.0f, -1.0f), new Vector2(-1.0f, 0.0f) };
    public Vector2 direction;

    // Use this for initialization
    void Start () {
		min = 4.025f;
        max = 6.525f;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Generate()
    {
        AumentDifficulty();

        enemyType = Random.Range(0, 4);
        generatorTimer = Random.Range(min, max);
        direction = directions[Random.Range(0, 4)];

        //Modificar esto acorde a direcciones y velocidades
        clone = Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
        clone.SendMessage("SetTipo", enemyType);
        clone.transform.position = new Vector3(direction.x * 1.2f, direction.y * 1.2f, 0f);
        clone.SendMessage("SetAnimation", direction);
        clone.SendMessage("Initiate");

        Invoke("Generate", generatorTimer);
    }

    public void AumentDifficulty()
    {
        if (min > 0.0f) {
            min = min - difficulty;
            max = max - difficulty;
        }
    }

    public void StopGenerate()
    {
        CancelInvoke("Generate");
    }
}
