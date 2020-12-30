using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D body;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }
    void _Move()
    {
        if (gameObject.activeInHierarchy)
        {
            body.position = new Vector2(body.position.x + speed * Time.deltaTime, body.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "DestroyArrow" || col.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
