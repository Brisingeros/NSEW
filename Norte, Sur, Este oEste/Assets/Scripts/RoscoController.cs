using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoscoController : MonoBehaviour {

    public GameObject rosco;
    private Transform bodyPos;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Inicio() {
        bodyPos = rosco.GetComponent<Transform>();
    }

    public void Rotate(string direc) {
        if (direc == "Arriba")
        {
            
        }
        else if (direc == "Derecha")
        {
            
        }
        else if (direc == "Abajo")
        {
            
        }
        else if (direc == "Izquierda")
        {
            
        }
    }
}
