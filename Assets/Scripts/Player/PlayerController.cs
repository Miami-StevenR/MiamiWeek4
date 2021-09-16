using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("Move: " + value.Get<Vector2>());
        var dir = value.Get<Vector2>().normalized;
        direction.x = dir.x;
        direction.z = dir.y;
    }
}
