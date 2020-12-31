using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.position = new Vector2(body.position.x,body.position.y + speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            body.position = new Vector2(body.position.x, body.position.y - speed * Time.deltaTime);
        }
        else
        {
            body.position = new Vector2(body.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }
}
