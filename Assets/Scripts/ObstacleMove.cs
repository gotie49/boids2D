using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class ObstacleMove : MonoBehaviour
{
    public AudioManager audioManager;
    public InputActionAsset movement;
    private InputAction move;
    private InputAction boost;
    [Range(1f, 10f)]
    public float moveSpeed = 3;

    public int killCount = 0;
    [Range(0f,100f)]
    public float boostPower;
    public BoostUI boostBar;
    Vector2 m;
    public Vector2 boundary;
    public GameObject explosion;
    void Awake()
    {
        move = movement.FindActionMap("Movement").FindAction("Move");
        boost = movement.FindActionMap("Movement").FindAction("Boost");

    }
    void Update()
    {
        m = move.ReadValue<Vector2>();
        float boostActive = boost.ReadValue<float>();      
        if(boostActive == 1 && boostPower>0)
        {
            transform.Translate(3f*m.normalized* Time.deltaTime*moveSpeed);
            boostPower-=10*Time.deltaTime;
            
        }
        else
        {
            transform.Translate(m.normalized* Time.deltaTime*moveSpeed);
            if(boostPower<0)
            {
                boostPower=0;
            }
        }
        boostBar.SetBoost(boostPower);
        
        //BoundaryCode
        if(Mathf.Abs(transform.position.x)>boundary.x)
        { 
            Vector3 TP  = transform.position; 
            TP.x = boundary.x * Mathf.Sign(transform.position.x);
            transform.position = TP;
        }
        if(Mathf.Abs(transform.position.y)>boundary.y)
        { 
            Vector3 TP  = transform.position; 
            TP.y = boundary.y * Mathf.Sign(transform.position.y);
            transform.position = TP;
        }
    }
    
    void OnEnable()
    {
        movement.FindActionMap("Movement").Enable();    
    }

    void OnDisable()
    {
        movement.FindActionMap("Movement").Disable();
    }
    void OnTriggerEnter2D(Collider2D collider)
    { 
        Instantiate(explosion,collider.gameObject.transform.position,Quaternion.identity);  
        //Debug.Log("Obstacle collided with " + agentCollider.name);
        if(collider.GetComponent<FlockAgent>())
        {         
            Destroy(collider.gameObject);
            audioManager.PlaySFX(audioManager.death);
            killCount++;
        }
        else if(collider.GetComponent<BoostObstacle>())
        {
           Destroy(collider.gameObject);
           audioManager.PlaySFX(audioManager.boostPickup);
           if(boostPower<34)
           {
                boostPower+=66;    
           }
           else
           {
                boostPower=100;
           }
        }
    }
    
}

