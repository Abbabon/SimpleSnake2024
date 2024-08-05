using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _snakePartPrefab;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _stepTimeout = 0.5f;
    
    private float _stepTimer = 0;
    private Vector3 _recentPlayerMovement;

    private List<GameObject> _snakeParts = new();

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        var initialSnakePart = Instantiate(_snakePartPrefab, Vector3.zero, Quaternion.identity);
        _snakeParts.Add(initialSnakePart);
    }

    void Update()
    {
        var playerInput = GetInputOnUpdate();
        if (playerInput != Vector3.zero)
        {
            _recentPlayerMovement = playerInput;
        }
        
        _stepTimer += Time.deltaTime;
        if (_stepTimer >= _stepTimeout)
        {
            if (_recentPlayerMovement == Vector3.zero)
                return;

            var newSnakeHeadPosition = _snakeParts.Last().transform.position + _recentPlayerMovement;
            var newSnakeHead = Instantiate(_snakePartPrefab, newSnakeHeadPosition, Quaternion.identity);
            _snakeParts.Add(newSnakeHead);
            
            var foundFood = _gameManager.IsThereFoodInPosition(newSnakeHead.transform.position);
            if (foundFood)
            {
                _gameManager.EatFood();
            }
            if (!foundFood)
            {
                var snakeTail = _snakeParts.First();
                _snakeParts.Remove(snakeTail);
                Destroy(snakeTail);
            }
            
            _stepTimer = 0;
        }
    }

    private Vector3 GetInputOnUpdate()
    {
        var movementDirection = new Vector3();
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movementDirection = Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movementDirection = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movementDirection = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movementDirection = Vector3.down;
        }

        return movementDirection;
    }
}
