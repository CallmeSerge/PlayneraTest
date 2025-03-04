using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _teg;
    public bool _isTakeApple {  get; private set; }
    private bool _isAppleStayOnFrool;

    private void OnMouseDrag()
    {
        _isTakeApple = true;
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
        transform.DOScale(0.4f, 0);
    }

    private void OnMouseUp()
    {
        _isTakeApple = false;
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2), -Vector2.up * 50, Color.blue, 60);
        RaycastHit2D ray2d = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2), -Vector2.up, 50);
        if (ray2d.collider != null)
        {
            if (_isAppleStayOnFrool == false)
            {
                FallingToFurniture(ray2d.collider);
            }
            else if(_isAppleStayOnFrool == true)
            {
                FallingToFloor();
            }
        }
    }

    private void FallingToFloor()
    {
        transform.DOScale(0.3f, 0.5f).SetEase(Ease.Linear);
    }

    private void FallingToFurniture(Collider2D target)
    {
        transform.DOMove(new Vector3(transform.position.x, target.transform.position.y), 1.5f).SetEase(Ease.OutBounce);
        transform.DOScale(0.3f, 0.5f).SetEase(Ease.Linear);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("floor"))
        {
            _isAppleStayOnFrool = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("floor"))
        {
            _isAppleStayOnFrool = false;
        }
    }

}
