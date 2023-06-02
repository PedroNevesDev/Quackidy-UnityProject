using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour ,IDamageable
{
    private static Duck instance;
    [SerializeField] float lerpAmmount;
    [SerializeField] float moveSpeed;
    [SerializeField] float pushForce;
    bool move = true;
    Rigidbody2D rb;

    public static Duck Instance { get => instance;}

    // Start is called before the first frame update
    void Awake()
    {
        if(instance)
            Destroy(instance);
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.up = Vector3.Lerp(transform.up,(Vector2)(transform.position - mousePosition), lerpAmmount * Time.deltaTime);
        if (move)
            Move();
    }

    private void Move()
    {
        rb.velocity = -transform.up * moveSpeed;
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
        move = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.Push( collision.transform.position- transform.position , pushForce);
    }
}

