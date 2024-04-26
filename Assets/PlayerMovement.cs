using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float vertical;
    private float horizontal;
    public Vector2 mousePosition;
    public Vector2 mouseDirection;
    bool dashcooldown;
    bool isDashing = false;
    [SerializeField] private float dashSpeed;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    private void FixedUpdate(){
        //rb.velocity = new Vector2(horizontal * -speed, rb.velocity.y);
        //rb.velocity = new Vector2(vertical * speed, rb.velocity.x);
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        if(isDashing){
            print("isDashing");
            rb.velocity = mouseDirection * dashSpeed;
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        mouseDirection = mouseDirection.normalized;
        rb.velocity = new Vector2(mousePosition.x, mousePosition.y);
        
        if(Input.GetKeyDown("x") && !dashcooldown){
            StartCoroutine("Dash");
        
        }
        
    }
        

     IEnumerator Dash(){
            print("function running");
            isDashing = true;
            dashcooldown = true;
            yield return new WaitForSeconds(0.1f);
            isDashing = false;
            yield return new WaitForSeconds(0.4f);
            dashcooldown = false;
            
    }
    }
    

