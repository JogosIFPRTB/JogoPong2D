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
    private float movimento; // Armazena o valor da entrada do jogador

    private void Start()
    {
        // Obtém a altura do batedor com base na escala do objeto
        altura = transform.localScale.y;

        // Captura os limites da tela
        Bola.emBaixoEsquerda = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Bola.emCimaDireita = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    /// <summary>
    /// Método chamado pelo Input System para capturar o movimento vertical.
    /// </summary>
    public void OnMove(InputValue value)
    {
        movimento = value.Get<float>();
    }

    private void Update()
    {
        // Calcula o movimento com base na entrada do jogador
        float deslocamento = movimento * velocidade * Time.deltaTime;

        // Obtém a posição atual
        Vector2 posicao = transform.position;

        // Limita o movimento do batedor dentro dos limites da tela
        posicao.y = Mathf.Clamp(posicao.y + deslocamento,
                                Bola.emBaixoEsquerda.y + altura / 2,
                                Bola.emCimaDireita.y - altura / 2);

        // Aplica a nova posição ao batedor
        transform.position = posicao;
    }
}
