using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartIt : MonoBehaviour {

    public int contador = 0;

    public GameObject[] menu;

    // Use this for initialization
    void Start () {

        for (int i = 1; i < menu.Length; i++) {
            menu[i].SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
        bool userAction = Input.GetKeyDown("up") || Input.GetMouseButtonDown(0);

        if (userAction && contador < 2)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                menu[i].SetActive(false);
            }

            contador++;

            //System.Threading.Thread.Sleep(1000);

            menu[contador].SetActive(true);
        }
        else if (contador == 3) {

        }
    }
}
