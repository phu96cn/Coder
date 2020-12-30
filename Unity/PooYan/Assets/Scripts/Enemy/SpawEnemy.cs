using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float speed;

    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(_Spaw());
    }

    // Update is called once per frame
    IEnumerator _Spaw()
    {
        yield return new WaitForSeconds(speed);
        float y = Random.Range(-4f,4f);
        body.position = new Vector2(body.position.x, y);
        Instantiate(enemy, body.position, Quaternion.identity);
        StartCoroutine(_Spaw());
    }
}
