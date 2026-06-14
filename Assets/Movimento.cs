using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimentação pelas setas ou WASD
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movX, 0, movZ) * velocidade * Time.deltaTime);

        // Funcionalidade 1: Pulo com a barra de espaço
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
    }
}