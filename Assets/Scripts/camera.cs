using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player; // nhân vật chơi

    public float start, end; // điểm bắt đầu và điểm kết thúc của màn chơi
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // vị trí của người chơi(nhân vật)
        var playerX = player.transform.position.x;
        // vị trí của camera
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;
        if (playerX > start && playerX < end)
        {
            // lấy vị trí của người chơi cập nhật vị trí cho cái camera để cam đi theo
            camX = playerX;
        }
        else
        {
            if (playerX < start)
            {
                playerX = start;
            }

            if (playerX > end)
            {
                playerX = end;
            }
        }
        //xét lại vị trí cho camera
        transform.position = new Vector3(camX, camY, camZ);
    }
}
