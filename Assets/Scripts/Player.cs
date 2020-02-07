using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    // Default Player Speed, Unity editable
    [SerializeField]    
    private float _speed = 3.5f; 
    void Start()
    {
        //Take the current position and assign start position(0,0,0)
        transform.position = new Vector3(0,0,0); //vector three

    }

    // Update is called once per frame
    void Update()
    {
        CalcMovement();

    }

    // player movement
    void CalcMovement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        // player virtical limit
        if (transform.position.y >= 0) 
        {
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        // player wrap left and right
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f,transform.position.y, 0);
        }

        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f,transform.position.y,0);
        }

    }
}
