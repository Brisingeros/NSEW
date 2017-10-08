using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esqueletoController : MonoBehaviour {

    public string[] andarAnimations; //RAVAm
    public string[] spawnDespawn;

    public Animator animator;
    public Rigidbody2D rb2d;

    public int tipo = 0; //RAVAm
    public Vector2 direc;

    public int index = 0;

    public float speed = 0.7f; //Ha trastear

	// Use this for initialization
	void Start () {

        andarAnimations = new string[16];
        spawnDespawn = new string[2];

        andarAnimations[0] = "RojoArriba";
        andarAnimations[1] = "RojoDerecha";
        andarAnimations[2] = "RojoAbajo";
        andarAnimations[3] = "RojoIzquierda";
        andarAnimations[4] = "AzulArriba";
        andarAnimations[5] = "AzulDerecha";
        andarAnimations[6] = "AzulAbajo";
        andarAnimations[7] = "AzulIzquierda";
        andarAnimations[8] = "VerdeArriba";
        andarAnimations[9] = "VerdeDerecha";
        andarAnimations[10] = "VerdeAbajo";
        andarAnimations[11] = "VerdeIzquierda";
        andarAnimations[12] = "AmarilloArriba";
        andarAnimations[13] = "AmarilloDerecha";
        andarAnimations[14] = "AmarilloAbajo";
        andarAnimations[15] = "AmarilloIzquierda";

        spawnDespawn[0] = "Spawn_Acierto";
        spawnDespawn[1] = "Fallo";


        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetTipo(int color) {
        tipo = color;
    }

    public void SetAnimation(Vector2 direction) {
        direc = direction;
    }

    public void Initiate() {
        if (direc.x == 0.0f && direc.y == 1.0f) //Arriba
        {
            index = 0;
        } else if (direc.x == 1.0f && direc.y == 0.0f) //Derecha
        {
            index = 1;
        }
        else if (direc.x == 0.0f && direc.y == -1.0f) //Abajo
        {
            index = 2;
        }
        else if (direc.x == -1.0f && direc.y == 0.0f) //Izquierda
        {
            index = 3;
        }

        Invoke("Generate", 0f);
    }

    public void Generate() {
        animator.Play(spawnDespawn[0]);

        Invoke("Animate", 0.517f);
    }

    public void Animate() {
        rb2d.velocity = new Vector2(direc.x * speed, direc.y * speed);

        animator.Play(andarAnimations[(tipo*4) + index]);
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public void Correcto() {
        animator.Play(spawnDespawn[0]);

        Invoke("Destroy", 0.517f);
    }

    public void Fallo()
    {
        animator.Play(spawnDespawn[1]);

        Invoke("Destroy", 0.517f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Puerta")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            string spriteName = other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name.Split('_')[2];

            if (spriteName == tipo.ToString()) {
                Correcto();
            } else {
                Fallo();
            }
        } 
        
        
    }
}
