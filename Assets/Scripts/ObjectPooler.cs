using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;

    void Start()
    {
        gameObjects = new List<GameObject>();

        for (int i = 0; i<numberOfObject; i++) {
            GameObject gameObject = Instantiate(pooledObject);
            gameObject.SetActive(false);
            gameObjects.Add(gameObject);
        }
    }

    public GameObject GetPooledGameObject() {
        foreach(GameObject gameObject1 in gameObjects) {
            if (!gameObject1.activeInHierarchy)
                return gameObject1;
        }

        GameObject gameObject = Instantiate(pooledObject);
        gameObject.SetActive(false);
        gameObjects.Add(gameObject);
        return gameObject;
    }

}
