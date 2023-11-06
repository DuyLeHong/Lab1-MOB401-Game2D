using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NhanVat : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private bool nen;

    public bool isRight = true;
    private int tong = 0;
    public Text diemText;

    public GameObject panels, buttons, texts;
    public AudioSource audio_src_vang;
    public AudioSource audio_src_play;
    public AudioSource audio_src_die;



    void tinhTong(int score)
    {
        tong += score;
        diemText.text = " " + tong;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tinhTong(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            anim.SetFloat("isRun", 1);
            diChuyenPhai();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            anim.SetFloat("isRun", 1);
            diChuyenTrai();
        }
        else
        {
            anim.SetFloat("isRun", 0);
        }

        if (nen && Input.GetKey(KeyCode.Space))
        {
            if (isRight)
            {
                audio_src_play.Play();

                rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }
            else
            {
                audio_src_play.Play();

                rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }

            nen = false;
        }
    }

    void diChuyenPhai()
    {
        transform.Translate(Time.deltaTime * 5, 0, 0);
        transform.localScale = new Vector3(1F, 1F, 1F);
    }

    void diChuyenTrai()
    {
        transform.Translate(-Time.deltaTime * 5, 0, 0);
        transform.localScale = new Vector3(-1F, 1F, 1F);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "vatcan")
        {
            nen = true;
        }

        if (collision.gameObject.tag == "vatcantrai")
        {
            
            audio_src_die.Play();   
            // // gameover, replace màn chơi
            Time.timeScale = 0; // dừng scene lại
            panels.SetActive(true); // show panel
            buttons.SetActive(true); // show button
       //   texts.SetActive(true); // show text
            diemText.text = " " + tong; // Hiển thị điểm hiện tại

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "vatcanxu")
        {
            audio_src_vang.Play();
            var name = collision.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            tinhTong(1);
        }
    }
}
