using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    public GameBehavior gameManager;
    private CapsuleCollider _col;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);
    }
    public int _playerHP = 10;
    public int _playerShield = 0;

    public void HealthChange()
    {
        gameManager._playerHP = this._playerHP;
        gameManager.SetHeartsDisplay(_playerHP);
    }
    public void ShieldChange()
    {
        gameManager._playerShield = this._playerShield;
        gameManager.SetShieldDisplay(_playerShield);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageArea")
        {
            if(_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Hit Damage area");
                Debug.Log(_playerHP);

            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            if (_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Enemy Hit");


            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
        if (collision.gameObject.name == "Enemy (1)")
        {
            if (_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Enemy Hit");


            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
        if (collision.gameObject.name == "Enemy (2)")
        {
            if (_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Enemy Hit");


            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
        if (collision.gameObject.name == "Enemy (3)")
        {
            if (_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Enemy Hit");


            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
        if (collision.gameObject.name == "Enemy (4)")
        {
            if (_playerShield > 0)
            {
                _playerShield--;
            }
            else
            {
                _playerHP -= 1;
                Debug.Log("Enemy Hit");


            }
            gameManager._playerHP = this._playerHP;
            gameManager._playerShield = this._playerShield;
            HealthChange();
            ShieldChange();
        }
    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }



}
