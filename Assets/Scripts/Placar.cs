using UnityEngine;
using TMPro; // Importa a biblioteca do TextMeshPro

/// <summary>
/// Classe responsável por controlar e exibir o placar do jogo.
/// Agora utiliza TextMeshProUGUI para melhor desempenho e aparência.
/// </summary>
public class Placar : MonoBehaviour
{
    private int ponto = 0; // Pontuação do jogador

    private TextMeshProUGUI placarTexto; // Referência ao componente de texto

    private void Start()
    {
        // Obtém referência ao componente TextMeshProUGUI
        placarTexto = GetComponent<TextMeshProUGUI>();

        // Inicializa o placar zerado
        AtualizarPlacar();
    }

    /// <summary>
    /// Adiciona um ponto ao placar do jogador.
    /// </summary>
    public void somaPonto()
    {
        ponto++; // Incrementa a pontuação
        AtualizarPlacar(); // Atualiza a exibição na tela
    }

    /// <summary>
    /// Retorna a pontuação atual do jogador.
    /// </summary>
    /// <returns>O valor atual da pontuação.</returns>
    public int verificaPonto()
    {
        return ponto;
    }

    /// <summary>
    /// Reseta a pontuação para zero.
    /// </summary>
    public void Resetar()
    {
        ponto = 0;
        AtualizarPlacar();
    }

    /// <summary>
    /// Atualiza o texto na tela com a pontuação atual.
    /// </summary>
    private void AtualizarPlacar()
    {
        placarTexto.text = ponto.ToString();
    }
}
