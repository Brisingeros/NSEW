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
        if (direc == "Arriba")
        {
            doorSprites[0].sprite = arriba[0];
            doorSprites[1].sprite = derecha[1];
            doorSprites[2].sprite = abajo[2];
            doorSprites[3].sprite = izquierda[3];
        }
        else if (direc == "Derecha") {
            doorSprites[0].sprite = arriba[3];
            doorSprites[1].sprite = derecha[0];
            doorSprites[2].sprite = abajo[1];
            doorSprites[3].sprite = izquierda[2];
        }
        else if (direc == "Abajo")
        {
            doorSprites[0].sprite = arriba[2];
            doorSprites[1].sprite = derecha[3];
            doorSprites[2].sprite = abajo[0];
            doorSprites[3].sprite = izquierda[1];
        }
        else if (direc == "Izquierda")
        {
            doorSprites[0].sprite = arriba[1];
            doorSprites[1].sprite = derecha[2];
            doorSprites[2].sprite = abajo[3];
            doorSprites[3].sprite = izquierda[0];
        }
    }
}
