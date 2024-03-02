using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float angle = 150.0f;

    private bool isLocationFound = false;

    LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();   
    }

    void Update()
    {
        if(levelManager.GetIsGameWon() == null)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
/*
        Vector3 movement = new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * angle * Time.deltaTime, 0);
        transform.Translate(movement);
*/
        Rigidbody rb = GetComponent<Rigidbody>();

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0f, 0f, moveVertical) * speed * Time.deltaTime * 30000;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, moveHorizontal * angle * Time.deltaTime, 0));

        rb.AddRelativeForce(movement);
        rb.MoveRotation(rb.rotation * deltaRotation);

        rb.drag = 5f; 
        rb.angularDrag = 5f;


        SetBoundaries();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Location"))
        {
            isLocationFound = true;
            Destroy(other.gameObject);
            Debug.Log("Location found");
        }
        else if (!other.gameObject.CompareTag("Ground"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }
    
    public bool GetIsLocationFound()
    {
        return isLocationFound;
    }

    public void SetIsLocationFound(bool value)
    {
        isLocationFound = value;
    }

    private void SetBoundaries()
    {
        Collider collider = GameObject.Find("Ground").GetComponent<Collider>();
        Bounds bounds = collider.bounds;
        Vector3 size = bounds.size;

        float minX = -bounds.size.x / 2f;
        float maxX = bounds.size.x / 2f;
        float minZ = -bounds.size.z / 2f;
        float maxZ = bounds.size.z / 2f;

        Vector3 position = transform.position;

        if (transform.position.x < minX)
        {
            position.x = minX;
        }
        if (transform.position.x > maxX)
        {
            position.x = maxX;
        }
        if (transform.position.z < minZ)
        {
            position.z = minZ;
        }
        if (transform.position.z > maxZ)
        {
            position.z = maxZ;
        }

        transform.position = position;
    }
}
