using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlataformaMovel : MonoBehaviour
{
    public Vector2 direcao = Vector2.right;
    public float velocidade = 2f;
    public float duracao = 5f;

    private Rigidbody2D rb;
    private bool ativada;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (ativada || !colisao.collider.CompareTag("Player")) return;

        ativada = true;
        StartCoroutine(Mover());
    }

    IEnumerator Mover()
    {
        rb.velocity = direcao.normalized * velocidade;
        yield return new WaitForSeconds(duracao);

        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
    }
}
