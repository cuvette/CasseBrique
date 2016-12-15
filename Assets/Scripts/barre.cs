using UnityEngine;
using System.Collections;

public class barre : MonoBehaviour
{

    public float vitesseBarre = 1f;


    private Vector3 joueurPos = new Vector3(0, -4.5f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * vitesseBarre);
        joueurPos = new Vector3(Mathf.Clamp(xPos, -9.5f, 9.5f), -4.5f, 0f);
        transform.position = joueurPos;

    }
}