using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BadDuck : MonoBehaviour,IDamageable
{
    [SerializeField] float lerpAmmount;
    [SerializeField] float moveSpeed;
    [SerializeField] float pushForce;
    Rigidbody2D rb;
    Transform target;
    bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        target = Duck.Instance.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.up = Vector3.Lerp(transform.up, transform.position - target.position, lerpAmmount * Time.deltaTime);
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
        print("pushed duck");
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
        
        collision.gameObject.GetComponent<IDamageable>()?.Push(collision.transform.position - transform.position  ,pushForce);
    }
}
