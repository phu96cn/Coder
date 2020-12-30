using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float shotSpeed;
    private bool isShot;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(_FireArrow());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            isShot = true;
        }

    }
    IEnumerator _FireArrow()
    {
        if (isShot)
        {
            anim.SetTrigger("Shoted");
            Instantiate(arrow, transform.position, Quaternion.Euler(1, 1, -90));
            yield return new WaitForSeconds(shotSpeed);
            isShot = false;
            anim.SetTrigger("Loaded");
        }
        yield return new WaitForSeconds(0);
        StartCoroutine(_FireArrow());
    }
}
