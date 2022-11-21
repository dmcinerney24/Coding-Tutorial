using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _facingDirection;

    public float rotationSpeed;
    public float moveSpeed;

    [SerializeField] [Tooltip("Insert Main Camera")]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
        MoveToCursor();
    }

    private void FaceMouse()
    {
        _facingDirection = (mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        float angle = Mathf.Atan2(_facingDirection.y, _facingDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void MoveToCursor()
    {
        Vector2 targetPosn = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, targetPosn, moveSpeed * Time.deltaTime);
        
    }
}
