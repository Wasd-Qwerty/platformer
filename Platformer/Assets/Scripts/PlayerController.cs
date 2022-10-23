using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 10;
    private Animator _anim;
    private bool _faceRight = true, _onGround;
    [SerializeField] private Transform _groundCheck;
    public int countOfKeys;
    public GameObject ground;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        CheckGround();
        RotateFace();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _faceRight = Input.GetAxis("Horizontal") > 0;
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rb.velocity.y);
            _anim.SetBool("walking", true);
        }
        else
        {
            _anim.SetBool("walking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "key")
        {
            countOfKeys += 1;
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "door")
        {
            print("Ты прошёл уровень");
            SceneManager.LoadScene("Level2");
        }
    }

    private void Jump()
    {
        if (_onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(transform.up * 13, ForceMode2D.Impulse);
            }
        }
    }


    private void CheckGround()
    {
        var col = Physics2D.OverlapCircleAll(_groundCheck.position, 0.2f);
        foreach (var item in col)
        {
            _onGround = item.gameObject == ground;
        }
    }
    private void RotateFace()
    {
        if (_faceRight)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
    }
}
