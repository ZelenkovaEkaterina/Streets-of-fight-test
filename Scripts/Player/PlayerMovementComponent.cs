using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        [SerializeField] internal float _speedMove = 2f;
        [SerializeField] private float _jumpForce = 4f;
        [SerializeField] private float _fallSpeed = 2f;
        
        [SerializeField] private float _rayDistance = 1f;
        [SerializeField] private LayerMask _groundLayerMask;

        private Vector2 _enemyDetected;
        [SerializeField] private LayerMask _enemyLayerMask;
        [SerializeField] private float _enemyDistance = .3f;
        [SerializeField] private GameObject _enemy;
        
        internal Rigidbody2D _rb;
        internal Vector2 _movement;

        internal bool isJumping;

        private IDamageble _damageble;
        private Weapon _weapon;
        private EnemyHealthComponent _enemyHealth;
        

        /*private void Start(){
        
             if (_damageble is DamageSystem handler)
             {
                 handler.OnDamageTaken += (damage, source) =>
                 {
                     Debug.Log($"Получен урон {damage}. Текущее здоровье {handler.CurrentrHealth}");
                 };
        
                 handler.OnDamageTaken += (damage, source) =>
                 {
                     if (handler.IsDead())
                     {
                         Debug.Log("Умер");
                     }
                 };
             }
        
        }*/
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _damageble = GetComponent<IDamageble>();
            _enemyHealth = GetComponent<EnemyHealthComponent>();
        }
    
        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = 0;
            
            if (_movement.x > 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                _enemyDetected = Vector2.right;
            }
            else if (_movement.x < 0)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
                _enemyDetected = Vector2.left;
            }
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }

            /*if (Input.GetKeyDown(KeyCode.F))
            {
                //_damageble?.TakeDamage(10, null);
            }*/

            //if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T) ||
            //        Input.GetKeyDown(KeyCode.Y)) && IsEnemy())
            //{
                //IsEnemy();
                //_weapon.Attack(null);
                //Debug.Log(null);
                //_damageble?.TakeDamage(10, null);
            //}
        }

        private void FixedUpdate()
        {
            //if (!IsGrounded())
           // {
              //  _rb.linearVelocity = new Vector2(_movement.x * _speedMove, _rb.linearVelocity.y);
           // }
           // else
           // {
                _movement.y = Input.GetAxisRaw("Vertical");
                _rb.linearVelocity = new Vector2(_movement.x * _speedMove, _movement.y * _speedMove);
           // }
        }

        internal bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                Vector2.down,
                _rayDistance,
                _groundLayerMask);
                
            if (hit.collider)
            {
                return true;
            }
            return false;
        }
        /*private bool IsEnemy()
        {
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                _enemyDetected,
                _rayDistance,
                _enemyLayerMask);

            if (hit.collider)
            {
                //Destroy(hit.collider.gameObject, .7f);
                return true;
            }
            return false;
        }*/
    }
}

