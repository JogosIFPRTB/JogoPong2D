using UnityEngine;

/// <summary>
/// Classe responsável pelo movimento da bola e a lógica de pontuação.
/// Agora garante que o Rigidbody2D esteja presente com [RequireComponent].
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Bola : MonoBehaviour
{
    // Velocidade da bola
    public float velocidade = 5f;

    // Direção da bola
    private Vector2 direcao;

    // Raio da bola (determinado automaticamente)
    private float raio;

    // Referência ao Rigidbody2D para movimentação
    private Rigidbody2D rb;

    // Referências aos placares dos jogadores
    public Placar placarEsquerda;
    public Placar placarDireita;

    // Definição da pontuação final para vencer o jogo
    public int pontuacaoFinal;

    // Posições dos limites da tela
    public static Vector2 emBaixoEsquerda;
    public static Vector2 emCimaDireita;

    private void Awake()
    {
        // Garante que o Rigidbody2D está presente e configurado corretamente
        rb = GetComponent<Rigidbody2D>();

        // Configura o Rigidbody2D para evitar rotação e permitir um movimento mais fluido
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void Start()
    {
        // Calcula o raio da bola com base na escala do objeto
        raio = transform.localScale.x / 2;

        // Captura os limites da tela
        emBaixoEsquerda = Camera.main.ScreenToWorldPoint(Vector2.zero);
        emCimaDireita = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Inicia a bola na posição central e com direção aleatória
        ReiniciarBola();
    }

    private void Update()
    {
        // Obtém a posição atual da bola
        Vector2 posicao = transform.position;

        // Verifica se a bola saiu pela esquerda (ponto do jogador da direita)
        if (posicao.x < emBaixoEsquerda.x + raio)
        {
            Debug.Log("Ponto da Direita");
            VerificaVitoria(placarDireita);
        }
        // Verifica se a bola saiu pela direita (ponto do jogador da esquerda)
        if (posicao.x > emCimaDireita.x - raio)
        {
            Debug.Log("Ponto da Esquerda");
            VerificaVitoria(placarEsquerda);
        }
    }

    /// <summary>
    /// Verifica se um jogador atingiu a pontuação máxima e reinicia a bola.
    /// </summary>
    /// <param name="placar">Placar do jogador que marcou ponto.</param>
    private void VerificaVitoria(Placar placar)
    {
        // Incrementa a pontuação do jogador
        placar.somaPonto();

        // Se o jogador atingiu a pontuação final, o jogo termina
        if (placar.verificaPonto() == pontuacaoFinal)
        {
            Time.timeScale = 0; // Pausa o jogo
            enabled = false; // Desativa a movimentação da bola
        }
        else
        {
            ReiniciarBola();
        }
    }

    /// <summary>
    /// Reinicia a bola no centro do campo e define uma nova direção aleatória.
    /// </summary>
    private void ReiniciarBola()
    {
        transform.position = Vector2.zero;
        DirecaoAleatoria();
    }

    /// <summary>
    /// Define uma direção aleatória para a bola no início de cada rodada.
    /// </summary>
    private void DirecaoAleatoria()
    {
        // Gera uma direção aleatória entre (1,1), (-1,1), (1,-1) e (-1,-1)
        direcao = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, Random.Range(0, 2) == 0 ? -1 : 1);

        // Aplica velocidade à bola na direção escolhida
        rb.linearVelocity = direcao * velocidade;
    }
}
