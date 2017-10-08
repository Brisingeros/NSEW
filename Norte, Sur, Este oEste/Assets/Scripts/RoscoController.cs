using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoscoController : MonoBehaviour
{

    public GameObject doors;
    public Animator animator;

    public int doorState;
    public int prevState;

    // Use this for initialization
    void Start()
    {
        doorState = 0;
        prevState = 0;

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        doorState = doors.GetComponent<DoorController>().state;

        if (prevState == 0)
        {
            if (doorState == 1)
            {
                animator.Play("1erCuartoI");
            }
            else if (doorState == 3)
            {
                animator.Play("1erCuartoD");
            }
        }
        else if (prevState == 1)
        {
            if (doorState == 0)
            {
                animator.Play("4erCuartoD");
            }
            else if (doorState == 2)
            {
                animator.Play("2erCuartoI");
            }
        }
        else if (prevState == 2)
        {
            if (doorState == 1)
            {
                animator.Play("3erCuartoD");
            }
            else if (doorState == 3)
            {
                animator.Play("3erCuartoI");
            }
        }
        else if (prevState == 3)
        {
            if (doorState == 0)
            {
                animator.Play("4erCuartoI");
            }
            else if (doorState == 2)
            {
                animator.Play("2erCuartoD");
            }
        }

        prevState = doorState;
    }
}
