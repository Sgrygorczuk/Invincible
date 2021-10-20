using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    Vector3 mousePosition; 
    public float moveSpeed = 0.1f;
    double rotation = 0;
    Rigidbody2D rigidbody;
    Vector2 position = new Vector2(0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        //Connects the object to the one in unity
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 oldPostion = position;
        Vector3 oldmousePosition = mousePosition; 
        //Updates the movement of the mouse 
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed);

        double x = mousePosition.x - oldmousePosition.x;
        double y = mousePosition.y - oldmousePosition.y;
        double distance = Math.Sqrt(x*x + y*y);
        print(distance);
        if(distance > 0.1){
            rotation =  (Math.Atan2(oldPostion.x - position.x,position.y -  oldPostion.y) * (180/Math.PI));
        }

    }

    private void FixedUpdate(){
        rigidbody.MovePosition(position);
        rigidbody.rotation = (float) rotation;
    }
}
