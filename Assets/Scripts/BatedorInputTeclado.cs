using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script responsável por capturar o input de teclado (ou joystick)
/// utilizando o novo sistema de Input da Unity (Input System).
/// Envia os dados capturados para o script de movimentação (BatedorMovimento).
/// </summary>
public class BatedorInputTeclado : MonoBehaviour
{
    private BatedorMovimento movimento; // Referência ao script de movimento

    private void Awake()
    {
        // Obtém a referência ao componente BatedorMovimento no mesmo GameObject
        movimento = GetComponent<BatedorMovimento>();
    }

    /// <summary>
    /// Método chamado automaticamente pelo Input System quando há entrada no eixo configurado.
    /// </summary>
    /// <param name="value">Valor do eixo vertical (float: -1 para baixo, 1 para cima, 0 parado)</param>
    public void OnMove(InputValue value)
    {
        float input = value.Get<float>(); // Captura o valor da entrada

        // Envia o valor para o script de movimentação
        movimento.DefinirMovimento(input);
    }
}