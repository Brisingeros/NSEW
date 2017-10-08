using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartIt : MonoBehaviour {

    public int contador = 0;

    public GameObject menu;
    public VideoPlayer video;
    public GameObject backGround;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        bool userAction = Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space);

        if (userAction) {
            if (contador == 0) {
                menu.SetActive(false);
                backGround.SetActive(false);

                video.Play();

                contador++;
            }
            else if (contador == 1)
            {
                SceneManager.LoadScene("GameScene");
            }
            
        }
    }
}
