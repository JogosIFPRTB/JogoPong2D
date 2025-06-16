using UnityEngine;

/// <summary>
/// Classe responsável pelo movimento da bola e a lógica de pontuação.
/// Agora garante que o Rigidbody2D esteja presente com [RequireComponent].
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Bola : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade da bola

    private Vector2 direcao; // Direção atual da bola
    private float raio;      // Raio da bola (calculado automaticamente)
    private Rigidbody2D rb;  // Referência ao Rigidbody2D

    private void Awake()
    {
        // Garante que o Rigidbody2D está presente e configurado corretamente
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;          // Remove influência da gravidade
        rb.freezeRotation = true;     // Impede que a bola gire fisicamente
    }

    /// <summary>
    /// Inicializa a bola, definindo seu raio e reiniciando no centro.
    /// </summary>
    public void IniciarBola()
    {
        raio = transform.localScale.x / 2; // Calcula raio com base na escala
        ReiniciarBola();
    }

    private void Update()
    {
        // Obtém a posição atual da bola
        Vector2 posicao = transform.position;

        // Verifica se a bola saiu pela esquerda (ponto do jogador da direita)
        if (posicao.x < GameManager.Instance.emBaixoEsquerda.x + raio)
        {
            Debug.Log("Ponto da Direita");
            GameManager.Instance.RegistrarPonto(GameManager.Instance.placarDireita);
        }
        // Verifica se a bola saiu pela direita (ponto do jogador da esquerda)
        if (posicao.x > GameManager.Instance.emCimaDireita.x - raio)
        {
            Debug.Log("Ponto da Esquerda");
            GameManager.Instance.RegistrarPonto(GameManager.Instance.placarEsquerda);
        }
    }

    /// <summary>
    /// Reinicia a bola no centro do campo e define uma nova direção aleatória.
    /// </summary>
    public void ReiniciarBola()
    {
        transform.position = Vector2.zero; // Coloca no centro
        DirecaoAleatoria();                // Define uma nova direção
    }

    /// <summary>
    /// Define uma direção aleatória para a bola no início de cada rodada.
    /// </summary>
    private void DirecaoAleatoria()
    {
        // Gera uma direção aleatória entre (1,1), (-1,1), (1,-1) e (-1,-1)
        direcao = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(0, 2) == 0 ? -1 : 1);
        //direcao = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(-1f, 1f)).normalized;

        // Aplica velocidade à bola na direção escolhida
        rb.linearVelocity = direcao * velocidade;
    }
}
