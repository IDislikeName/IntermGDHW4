using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject bullet;
    public int maxCD=3;
    public float currentCD=0;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&&currentCD<=0){
            GameObject bul =  Instantiate(bullet);
            bul.transform.position = transform.position;
            if (left){
                bul.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,0);
            }
            else
            {
                bul.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
            }
            currentCD = maxCD;
        }
        currentCD -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horiz*speed,vert*speed);
        if (horiz > 0)
        {
            transform.localScale = new Vector3 (0.5f,transform.localScale.y, transform.localScale.z);
            left = false;
        }
        if (horiz < 0)
        {
            transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
            left = true;
        }
    }
}
