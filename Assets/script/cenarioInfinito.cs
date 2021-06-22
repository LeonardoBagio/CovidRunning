using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenarioInfinito : MonoBehaviour
{

public float velocidadeDoScroll;

void Update ()
{
	Vector2 offset = new Vector2(Time.time * velocidadeDoScroll,0);
	GetComponent<Renderer>().material.mainTextureOffset = offset;
}

}