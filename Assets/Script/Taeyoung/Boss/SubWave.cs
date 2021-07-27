using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWave : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D collider;
    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        StartCoroutine(Turnof());
    }
    public void Turn()
    {
        StartCoroutine(Turnof());
    }
    public IEnumerator Turnof()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(.6f);
        collider.enabled = true;
    }
}
