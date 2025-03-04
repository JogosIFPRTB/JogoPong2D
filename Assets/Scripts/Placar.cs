using UnityEngine;
using TMPro; // Importa a biblioteca do TextMeshPro

/// <summary>
/// Classe responsável por controlar e exibir o placar do jogo.
/// Agora utiliza TextMeshProUGUI para melhor desempenho e aparência.
/// </summary>
public class Placar : MonoBehaviour
{
    // Variável para armazenar a pontuação do jogador
    private int ponto;

    // Referência ao componente de texto (TextMeshPro)
    private TextMeshProUGUI placarTexto;

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
    /// Atualiza o texto do placar na interface do usuário.
    /// </summary>
    private void AtualizarPlacar()
    {
        placarTexto.text = ponto.ToString();
    }
}
