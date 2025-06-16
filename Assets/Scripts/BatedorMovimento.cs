using UnityEngine;

/// <summary>
/// Responsável por movimentar o batedor no eixo Y,
/// limitado pelos limites da tela definidos no GameManager.
/// Este script recebe um valor de entrada vindo dos scripts de Input
/// e aplica esse movimento ao batedor.
/// </summary>
public class BatedorMovimento : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f; // Velocidade de movimento (pode ser alterada no inspetor)

    private float altura; // Altura do batedor, calculada automaticamente
    private float movimento; // Valor da entrada (-1 para baixo, 1 para cima, 0 parado)

    private void Start()
    {
        // Obtém a altura do batedor com base na escala do objeto
        altura = transform.localScale.y;
    }

    private void Update()
    {
        // Calcula o deslocamento multiplicando o valor da entrada pela velocidade e pelo deltaTime (tempo entre frames)
        float deslocamento = movimento * velocidade * Time.deltaTime;

        // Pega a posição atual do batedor
        Vector2 posicao = transform.position;

        // Atualiza a posição no eixo Y, limitando entre os limites da tela
        posicao.y = Mathf.Clamp(posicao.y + deslocamento,
            GameManager.Instance.emBaixoEsquerda.y + altura / 2, // Limite inferior da tela
            GameManager.Instance.emCimaDireita.y - altura / 2);   // Limite superior da tela

        // Aplica a nova posição no objeto
        transform.position = posicao;
    }

    /// <summary>
    /// Método chamado pelos scripts de Input para definir o valor de movimento.
    /// </summary>
    /// <param name="input">Valor de entrada (-1, 0 ou 1)</param>
    public void DefinirMovimento(float input)
    {
        movimento = input;
    }
}