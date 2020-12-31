using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public static Common s_Instance;
    // Start is called before the first frame update
    void Start()
    {
        _makeInstance();
    }
    void _makeInstance()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
        }
    }
    public List<GameObject> _poolObjectToList(GameObject gameobject, int amount)
    {
        List<GameObject> listGameObject = new List<GameObject>();
        for(int i = 0; i< amount; i++)
        {
            GameObject obj = (GameObject)Instantiate(gameobject);
            obj.SetActive(false);
            listGameObject.Add(obj);
        }
        return listGameObject;
    }

    public GameObject GetGameObject(List<GameObject> listGameObject, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if (!listGameObject[i].activeInHierarchy)
            {
                return listGameObject[i];
            }
        }
        return null;
    }
    // Update is called once per frame
}
