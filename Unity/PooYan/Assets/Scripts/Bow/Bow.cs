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

    private List<GameObject> m_PooledObject;
    [SerializeField]
    private int m_AmountPool;
    // Start is called before the first frame update
    void Start()
    {
        _PoolObject();
        anim = GetComponent<Animator>();
        StartCoroutine(_FireArrow());
    }

    void _PoolObject()
    {
        m_PooledObject = new List<GameObject>();
        for (int i = 0;i< m_AmountPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(arrow);
            obj.SetActive(false);
            m_PooledObject.Add(obj);
        }
    }
    GameObject _GetPoolObject()
    {
        for(int i = 0; i < m_AmountPool; i++)
        {
            if (!m_PooledObject[i].activeInHierarchy)
            {
                return m_PooledObject[i];
            }
        }
        return null;
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
            //Instantiate(arrow, transform.position, Quaternion.Euler(1, 1, -90));
            GameObject arrow = _GetPoolObject();
            if(arrow != null)
            {
                arrow.transform.position = transform.position;
                //arrow.transform.rotation = transform.rotation;
                arrow.SetActive(true);
            }
            yield return new WaitForSeconds(shotSpeed);
            isShot = false;
            anim.SetTrigger("Loaded");
        }
        yield return new WaitForSeconds(0);
        StartCoroutine(_FireArrow());
    }
}
