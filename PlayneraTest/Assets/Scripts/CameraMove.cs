using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private GamePlay _gamePlay;
    [SerializeField] private float _cameraMoveMagnitude;
    private bool _isGoingToLeft = false;
    private bool _isGoingToRight = false;

    void Update()
    {
        if (_isGoingToLeft && _gamePlay._isTakeApple)
        {
            transform.Translate(Vector2.left * _cameraSpeed * Time.deltaTime);
        }
        if (_isGoingToRight && _gamePlay._isTakeApple)
        {
            transform.Translate(Vector2.right * _cameraSpeed * Time.deltaTime);
        }
        if (transform.position.x > 21)
        {
            transform.position = new Vector3(21, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -21)
        {
            transform.position = new Vector3(-21, transform.position.y, transform.position.z);
        }
    }

    public void CameraGoToLeft()
    {
        _isGoingToLeft = true;
    }
    public void CameraGoToRight()
    {
        _isGoingToRight = true;
    }
    public void CameraStop()
    {
        _isGoingToLeft = false;
        _isGoingToRight = false;
    }
}
