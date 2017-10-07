using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject[] doors;
    private SpriteRenderer[] doorSprites;

    public Sprite[] arriba;
    public Sprite[] derecha;
    public Sprite[] abajo;
    public Sprite[] izquierda;

    private int state = 0;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Inicio() {
        doorSprites = new SpriteRenderer[4];

        for (int i = 0; i < doors.Length; i++)
        {
            doorSprites[i] = doors[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ChangeSprite(string direc) {
        if (direc == "Derecha")
        {
            if (state == 0)
            {
                state = 3;
            }
            else
            {
                state--;
            }
        }
        else if (direc == "Izquierda") {
            if (state == 3)
            {
                state = 0;
            }
            else {
                state++;
            }
        }

        doorSprites[0].sprite = arriba[state];
        doorSprites[1].sprite = derecha[(state + 1) % 4];
        doorSprites[2].sprite = abajo[(state + 2) % 4];
        doorSprites[3].sprite = izquierda[(state + 3) % 4];
    }
}
