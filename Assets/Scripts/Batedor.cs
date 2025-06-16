using UnityEngine;
using UnityEngine.InputSystem; // Importa o novo sistema de entrada

/// <summary>
/// Classe responsável pelo controle dos batedores do jogo (jogadores).
/// Implementada com o novo Unity Input System.
/// </summary>
public class Batedor : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f; // Velocidade do batedor

    private float altura; // Altura do batedor
    private float movimento; // Armazena o valor da entrada do jogador  (valor entre -1 e 1)

    private void Start()
    {
        // Obtém a altura do batedor com base na escala do objeto
        altura = transform.localScale.y;
    }

    /// <summary>
    /// Método chamado pelo Input System para capturar o movimento vertical do jogador.
    /// </summary>
    /// <param name="value">Valor de entrada (float)</param>
    public void OnMove(InputValue value)
    {
        movimento = value.Get<float>(); // Captura movimento vertical do jogador
    }

    private void Update()
    {
        // Calcula o deslocamento com base na entrada, velocidade e deltaTime
        float deslocamento = movimento * velocidade * Time.deltaTime;

        // Obtém a posição atual
        Vector2 posicao = transform.position;

        // Limita o movimento do batedor dentro dos limites da tela
        posicao.y = Mathf.Clamp(posicao.y + deslocamento,
            GameManager.Instance.emBaixoEsquerda.y + altura / 2,
            GameManager.Instance.emCimaDireita.y - altura / 2);

        // Aplica a nova posição ao batedor
        transform.position = posicao;
    }
}
