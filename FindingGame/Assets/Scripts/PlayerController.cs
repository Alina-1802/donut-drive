using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float angle = 150.0f;

    private bool isLocationFound = false;

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(0,0,Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * angle * Time.deltaTime, 0);
        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Location"))
        {
            isLocationFound = true;
            Destroy(other.gameObject);
            Debug.Log("Location found");
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
}
