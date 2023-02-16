using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 0.3f;

    Vector3 m_moveLimit = new Vector3(17.6f, 0, 36.2f);
    //Vector2 m_moveLimity = new Vector2(0,36.29f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        transform.localPosition = ClampPosition(transform.localPosition);
    }

    void PlayerInput()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(MoveSpeed,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-MoveSpeed,0,0);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0,0,MoveSpeed);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,0,-MoveSpeed);
        }
    }

    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            //좌우로 움직이는 이동범위 Mathf.Clamp(value, min, max)
            Mathf.Clamp(position.x, -m_moveLimit.x, m_moveLimit.x),
            0f,
            Mathf.Clamp(position.z, -m_moveLimit.z, m_moveLimit.z)
        );
    }

}
