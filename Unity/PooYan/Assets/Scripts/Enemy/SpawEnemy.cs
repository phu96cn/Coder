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
    private List<GameObject> listEnemy;
    [SerializeField]
    private int amount;
    // Start is called before the first frame update
    void Start()
    {
        listEnemy = Common.s_Instance._poolObjectToList(enemy, amount);
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(_Spaw());
    }

    // Update is called once per frame
    IEnumerator _Spaw()
    {
        yield return new WaitForSeconds(speed);
        float y = Random.Range(-4f,4f);
        body.position = new Vector2(body.position.x, y);
        GameObject enemy = Common.s_Instance.GetGameObject(listEnemy, amount);
        if(enemy != null)
        {
            enemy.transform.position = new Vector2(transform.position.x, y);
            enemy.SetActive(true);
        }
        StartCoroutine(_Spaw());
    }
}
