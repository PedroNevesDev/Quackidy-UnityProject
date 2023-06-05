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
        Vector3 mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,lerpAmmount *Time.deltaTime);
        if (move)
            Move();
    }

    private void Move()
    {
        rb.velocity = transform.up * moveSpeed;
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
        collision.gameObject.GetComponent<IDamageable>()?.Push( collision.transform.position- transform.position , pushForce);
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IInteractable>()?.Interact();
    }
}

