using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Idle, Playing, Ended, Ready }

public class GameController : MonoBehaviour {

    public GameState gameState = GameState.Idle;

    public GameObject uiIdle;   //Texto antes de empezar a jugar

    public GameObject generator;    //Generador de mobs
    private AudioSource musicPlayer; //Manejar la música

    public GameObject doors;

	// Use this for initialization
	void Start () {
        musicPlayer = GetComponent<AudioSource>();

        doors.SendMessage("Inicio");
        //Función para rotar las puertas
        //doors.SendMessage("ChangeSprite", "Derecha");
        //doors.SendMessage("ChangeSprite", "Derecha");
        //doors.SendMessage("ChangeSprite", "Derecha");
        //doors.SendMessage("ChangeSprite", "Izquierda");
    }
	
	// Update is called once per frame
	void Update () {
        bool userAction = Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("left") || Input.GetKeyDown("right");

        if (gameState == GameState.Idle && userAction)
        {
            //Quitar texto y empezar a jugar
            gameState = GameState.Playing;
            uiIdle.SetActive(false);

            //Poner en marcha el generador
            generator.SendMessage("Generate");

            //Música
            musicPlayer.Play();
        }
        else if (gameState == GameState.Ready) {
            if (userAction) {
                RestartGame();
            }
        }

    }

    public void RestartGame() {
        SceneManager.LoadScene("GameScene");
    }
}
