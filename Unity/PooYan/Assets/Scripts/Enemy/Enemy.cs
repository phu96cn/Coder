using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Animator anim;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.position = new Vector2(body.position.x - speed * Time.deltaTime,body.position.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrow")
        {
            StartCoroutine( _Destroy());
        }
    }
    IEnumerator _Destroy()
    {
        anim.SetTrigger("Explosion");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
