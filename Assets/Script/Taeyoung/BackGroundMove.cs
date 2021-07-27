using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    [SerializeField]
    private float speed;
    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
