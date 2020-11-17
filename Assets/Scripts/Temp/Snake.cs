using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float Step = 2;
    public float Time = 0.5f;
    public Transform StartPoint;

    public Vector2 Direction;
    private MoveState _moveState;
    private bool _cooldown = false;

    public int TailLength = 3;
    public GameObject TailPrefab;

    public GameObject GridPrefabBlack;
    public GameObject GridPrefabGray;
    public int GridSize = 10;

    void Start()
    {
        GridCreator();
    }

    public void GridCreator()
    {
        for (int x = 0 - (GridSize / 2) ; x < GridSize/2; x++)
        {
            for (int z = 0 - (GridSize / 2); z < GridSize/2; z++)
            {
                if ( x != 0 && x % 2 == 0 && z != 0 && (z + 1) % 2 == 0 || x == 0 && z != 0 && (z + 1) % 2 == 0 || z != 0 && (x + 1) % 2 == 0 && z % 2 == 0 || z == 0 && x > 0 && (x + 1) % 2 == 0 || z == 0 && x < 0 && (x - 1) % 2 == 0)
                {
                    Instantiate(GridPrefabBlack, new Vector3(x * Step, 0, z * Step), Quaternion.identity);
                }
                else
                {
                    Instantiate(GridPrefabGray, new Vector3(x * Step, 0, z * Step), Quaternion.identity);
                }
            }
        }
    }

    IEnumerator Cooldown()
    {
        _cooldown = true;
        yield return new WaitForSeconds(Time);
        _cooldown = false;
    }





    IEnumerator TailCreator()
    {
        var position = transform.position;
        yield return new WaitForSeconds(Time);
        Instantiate(TailPrefab, position, Quaternion.identity);
    }







    public void Move()
    {
        if (!_cooldown)
        {
            transform.position = new Vector3(transform.position.x + Direction.x, transform.position.y, transform.position.z + Direction.y);
            StartCoroutine(TailCreator());
            StartCoroutine(Cooldown());
        }
        
    }
    public void MoveDirection()
    {
        switch (_moveState)
        {
            case MoveState.Up:
                Direction = new Vector2(0, Step);
                break;
            case MoveState.Down:
                Direction = new Vector2(0, Step * (-1));
                break;
            case MoveState.Left:
                Direction = new Vector2(Step * (-1), 0);
                break;
            case MoveState.Right:
                Direction = new Vector2(Step, 0);
                break;
        }
    }
    public void SnakeRotation()
    {
        switch (_moveState)
        {
            case MoveState.Up:
                transform.rotation = Quaternion.Euler(0f , 0f , 0f);
                break;
            case MoveState.Down:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case MoveState.Left:
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                break;
            case MoveState.Right:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
        }
    }

    public void InputState()
    {
        if (Input.GetKey(KeyCode.W) && _moveState != MoveState.Down)
        {
            _moveState = MoveState.Up;
        }
        else if (Input.GetKey(KeyCode.S) && _moveState != MoveState.Up)
        {
            _moveState = MoveState.Down;
        }
        else if (Input.GetKey(KeyCode.A) && _moveState != MoveState.Right)
        {
            _moveState = MoveState.Left;
        }
        else if (Input.GetKey(KeyCode.D) && _moveState != MoveState.Left)
        {
            _moveState = MoveState.Right;
        }
    }

    void Update()
    {
        InputState();
        MoveDirection();
        SnakeRotation();
        Move();
    }


}

public enum MoveState
{
    Up,
    Down,
    Left,
    Right
}
