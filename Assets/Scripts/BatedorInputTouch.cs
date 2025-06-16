using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script responsável por capturar o input de toque na tela
/// utilizando o Input System. Funciona dividindo a tela em duas metades:
/// metade esquerda controla o jogador da esquerda e metade direita controla o jogador da direita.
/// </summary>
public class BatedorInputTouch : MonoBehaviour
{
    [SerializeField] private bool isLeftPlayer = true; // Define se este batedor é o da esquerda (true) ou da direita (false)

    private BatedorMovimento movimento; // Referência ao script de movimentação
    private InputAction touchPositionAction; // Ação do Input System para capturar a posição do toque

    private void Awake()
    {
        // Obtém o componente de movimentação no mesmo GameObject
        movimento = GetComponent<BatedorMovimento>();
    }

    private void OnEnable()
    {
        // Obtém o componente PlayerInput e a ação de toque configurada no Input Actions
        var playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];

        // Ativa a captura do toque
        touchPositionAction.Enable();
    }

    private void OnDisable()
    {
        // Desativa a captura do toque quando o objeto for desativado
        touchPositionAction.Disable();
    }

    private void Update()
    {
        // Lê a posição atual do toque na tela (em pixels)
        Vector2 toque = touchPositionAction.ReadValue<Vector2>();

        // Verifica se há toque na tela (se não há, o valor é zero)
        if (toque != Vector2.zero)
        {
            // Converte a posição do toque de pixels para coordenadas do mundo
            Vector3 toquePos = Camera.main.ScreenToWorldPoint(toque);

            // Verifica se o toque está na metade correta da tela (esquerda ou direita)
            if ((toquePos.x < 0 && isLeftPlayer) || (toquePos.x > 0 && !isLeftPlayer))
            {
                // Calcula a direção:
                // Se o toque está acima do batedor, move para cima (1)
                // Se está abaixo, move para baixo (-1)
                float direcao = toquePos.y > transform.position.y ? 1 : -1;

                // Se estiver muito próximo (diferença menor que 0.1), não se move (0)
                if (Mathf.Abs(toquePos.y - transform.position.y) < 0.1f)
                    direcao = 0;

                // Envia o valor de direção para o script de movimentação
                movimento.DefinirMovimento(direcao);
            }
            else
            {
                // Se o toque não está na metade correta, não se move
                movimento.DefinirMovimento(0);
            }
        }
        else
        {
            // Se não há toque, para o movimento
            movimento.DefinirMovimento(0);
        }
    }
}
