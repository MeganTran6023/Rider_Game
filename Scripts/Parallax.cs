using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    //acess to material for background
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;

    private void Awake()
    {

        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        //speed of background movement
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);

    }

}
