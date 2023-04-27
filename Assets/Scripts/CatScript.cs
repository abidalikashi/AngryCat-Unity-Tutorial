using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public Rigidbody2D catRigidBody;
    public float flapStrength;
    public LogicManager logic;
    public bool catIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && catIsAlive)
        {
            catRigidBody.velocity = Vector2.up * flapStrength;
            SFXController.Instance.playSFXClip(0);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(catIsAlive)
        {
            logic.gameOver();
            catIsAlive = false;
        }

    }
}
