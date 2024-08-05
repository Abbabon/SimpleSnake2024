using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _food;
    
    private void Awake()
    {
        _food = GameObject.Find("Food");
        if (_food != null)
            Debug.Log("Found Food");
        else
            Debug.LogError("Did not find food!");
    }

    public bool IsThereFoodInPosition(Vector3 snakePosition)
    {
        if (_food == null)
            return false;
        
        return _food.transform.position == snakePosition;
    }

    public void EatFood()
    {
        Destroy(_food);
        // TODO: spawn food in another space
    }
}
