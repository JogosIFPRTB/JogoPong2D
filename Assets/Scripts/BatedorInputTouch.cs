using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script respons�vel por capturar o input de toque na tela
/// utilizando o Input System. Funciona dividindo a tela em duas metades:
/// metade esquerda controla o jogador da esquerda e metade direita controla o jogador da direita.
/// </summary>
public class BatedorInputTouch : MonoBehaviour
{
    [SerializeField] private bool isLeftPlayer = true; // Define se este batedor � o da esquerda (true) ou da direita (false)

    private BatedorMovimento movimento; // Refer�ncia ao script de movimenta��o
    private InputAction touchPositionAction; // A��o do Input System para capturar a posi��o do toque

    private void Awake()
    {
        // Obt�m o componente de movimenta��o no mesmo GameObject
        movimento = GetComponent<BatedorMovimento>();
    }

    private void OnEnable()
    {
        // Obt�m o componente PlayerInput e a a��o de toque configurada no Input Actions
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
        // L� a posi��o atual do toque na tela (em pixels)
        Vector2 toque = touchPositionAction.ReadValue<Vector2>();

        // Verifica se h� toque na tela (se n�o h�, o valor � zero)
        if (toque != Vector2.zero)
        {
            // Converte a posi��o do toque de pixels para coordenadas do mundo
            Vector3 toquePos = Camera.main.ScreenToWorldPoint(toque);

            // Verifica se o toque est� na metade correta da tela (esquerda ou direita)
            if ((toquePos.x < 0 && isLeftPlayer) || (toquePos.x > 0 && !isLeftPlayer))
            {
                // Calcula a dire��o:
                // Se o toque est� acima do batedor, move para cima (1)
                // Se est� abaixo, move para baixo (-1)
                float direcao = toquePos.y > transform.position.y ? 1 : -1;

                // Se estiver muito pr�ximo (diferen�a menor que 0.1), n�o se move (0)
                if (Mathf.Abs(toquePos.y - transform.position.y) < 0.1f)
                    direcao = 0;

                // Envia o valor de dire��o para o script de movimenta��o
                movimento.DefinirMovimento(direcao);
            }
            else
            {
                // Se o toque n�o est� na metade correta, n�o se move
                movimento.DefinirMovimento(0);
            }
        }
        else
        {
            // Se n�o h� toque, para o movimento
            movimento.DefinirMovimento(0);
        }
    }
}
