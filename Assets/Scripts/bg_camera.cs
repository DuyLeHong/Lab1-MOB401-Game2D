using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_camera : MonoBehaviour
{
    public float speed = 0.1f;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
    }
}
