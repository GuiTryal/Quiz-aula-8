using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jogador : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidade, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
    }
}
