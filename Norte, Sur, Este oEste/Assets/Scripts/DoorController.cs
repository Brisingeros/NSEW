using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour {

    public GameObject[] doors;
    private SpriteRenderer[] doorSprites;

    public GameObject rosco;

    public Sprite[] arriba;
    public Sprite[] derecha;
    public Sprite[] abajo;
    public Sprite[] izquierda;

    public int state = 0; //ADAI

    //Si estado es 0 arriba está norte - rojo Arriba
    //Si estado es 1 arriba está este - verde izquierda
    //Si estado es 2 arriba está sur - azul Abajo
    //Si estado es 3 arriba está oeste - amarillo Derecha

    // Use this for initialization
    void Start () {
        doorSprites = new SpriteRenderer[4];

        for (int i = 0; i < doors.Length; i++)
        {
            doorSprites[i] = doors[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            CambioDerecha();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            CambioIzquierda(); 
        }
		
	}

    void CambioDerecha() {
        if (state == 0)
        {
            state = 3;
        }
        else
        {
            state--;
        }

        Invoke("ChangeSprite", 0.1f);
    }

    void CambioIzquierda()
    {
        if (state == 3)
        {
            state = 0;
        }
        else
        {
            state++;
        }

        Invoke("ChangeSprite", 0.1f);
    }

    public void ChangeSprite() {

        doorSprites[0].sprite = arriba[state];
        doorSprites[1].sprite = derecha[(state + 1) % 4];
        doorSprites[2].sprite = abajo[(state + 2) % 4];
        doorSprites[3].sprite = izquierda[(state + 3) % 4];

    }

    public int GetState() {
        return state;
    }
}
