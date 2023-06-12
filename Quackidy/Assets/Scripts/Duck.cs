using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Duck : MonoBehaviour, IDamageable
{
    private static Duck instance;
    [SerializeField] float lerpAmmount;
    [SerializeField] float moveSpeed;
    [SerializeField] float pushForce;
    [SerializeField] float minValueToLose;
    float speedBoost = 1f;
    float slow = 1f;
    bool move = true;
    Rigidbody2D rb;
    UIManager ui;


    public static Duck Instance { get => instance; }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
            Destroy(instance);
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ui = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetKeyDown(KeyCode.Mouse0) && ui)
        {
            speedBoost = 2f;
            ui.FoodToLoseBoost = 3f;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && ui)
        {
            speedBoost = 1f;
            ui.FoodToLoseBoost = 1;
        }
        if (move)
            Move();


    }


    private void Move()
    {
        rb.velocity = transform.up * moveSpeed * speedBoost * slow;
    }

    public void Push(Vector2 direction, float pushForce)
    {
        rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
        print("pushed bad duck");
        StartCoroutine(StunCooldown());
    }

    IEnumerator StunCooldown()
    {
        move = false;
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector3.zero;
        //rb.angularVelocity = 0;
        move = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.Push(collision.transform.position - transform.position, pushForce);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable seed = collision.gameObject.GetComponent<IInteractable>();
        if (seed != null)
        {
            moveSpeed += seed.SpeedToAdd;
            ui.AddFood(seed.FoodToAdd);
            seed.Interact();
        }


    }

    public void SlowDown()
    {
        slow = 0.75f;
    }

    public void StopSlow()
    {
        slow = 1 ;
    }
}

