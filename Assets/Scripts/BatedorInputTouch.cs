using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script responsável por capturar os toques na tela.
/// Permite que dois jogadores, cada um de um lado da tela (esquerda ou direita),
/// controlem seus batedores em um jogo (ex.: Pong ou Air Hockey).
/// Funciona em dispositivos com tela sensível ao toque (mobile ou tablets).
/// Cada jogador toca na sua metade da tela:
/// - Se tocar acima do batedor, ele sobe.
/// - Se tocar abaixo, ele desce.
/// - Se não tocar, o batedor para.
/// Suporte completo a múltiplos toques simultâneos.
/// </summary>
[RequireComponent(typeof(BatedorMovimento))] // Garante que este GameObject tenha o script de movimento
public class BatedorInputTouch : MonoBehaviour
{
    // ==== CONFIGURAÇÕES ====

    [Header("Configurações do Jogador")]
    [Tooltip("Se verdadeiro, este batedor é o da esquerda. Se falso, é o da direita.")]
    [SerializeField] private bool isLeftPlayer = true;

    [Header("Configurações de Sensibilidade")]
    [Tooltip("Define a distância mínima (em unidades) para considerar que o batedor deve se mover. Serve para ignorar pequenos toques que poderiam gerar tremores.")]
    [SerializeField] private float deadZone = 0.1f;


    // ==== VARIÁVEIS INTERNAS ====

    // Referência ao script que faz o batedor se mover
    private BatedorMovimento movimento;

    // Referência à câmera principal da cena (necessária para converter a posição do toque para o mundo do jogo)
    private Camera mainCamera;


    // ==== MÉTODOS DO CICLO DE VIDA ====

    /// <summary>
    /// Awake é chamado assim que o objeto é criado, antes de Start.
    /// Usamos aqui para pegar as referências necessárias.
    /// </summary>
    private void Awake()
    {
        // Pegamos o componente BatedorMovimento que está no mesmo objeto
        movimento = GetComponent<BatedorMovimento>();

        // Pegamos a referência da câmera principal
        mainCamera = Camera.main;
    }

    /// <summary>
    /// Update é chamado uma vez por frame (a todo momento que o jogo está rodando).
    /// Aqui fazemos a leitura dos toques na tela.
    /// </summary>
    private void Update()
    {
        // Verifica se há uma tela sensível ao toque disponível
        if (Touchscreen.current != null)
        {
            // Verifica se existem toques ativos na tela
            if (Touchscreen.current.touches.Count > 0)
            {
                bool toqueValidoEncontrado = false; // Controla se achamos um toque na metade da tela do jogador

                // Percorre todos os toques ativos na tela
                foreach (var touchControl in Touchscreen.current.touches)
                {
                    // Verifica se este toque está pressionado (dedo encostando na tela)
                    if (touchControl.press.isPressed)
                    {
                        // Lê a posição do toque em pixels na tela
                        Vector2 touchPos = touchControl.position.ReadValue();

                        // Converte a posição da tela (2D em pixels) para o mundo do jogo (3D em unidades Unity)
                        Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 0));

                        // Verifica se o toque está na metade correta da tela:
                        // - Se for o jogador da esquerda, o toque deve estar com worldPos.x < 0
                        // - Se for o jogador da direita, o toque deve estar com worldPos.x > 0
                        bool toqueValido = (worldPos.x < 0 && isLeftPlayer) || (worldPos.x > 0 && !isLeftPlayer);

                        if (toqueValido)
                        {
                            // Calcula a diferença na posição Y entre o toque e o batedor
                            float diferencaY = worldPos.y - transform.position.y;

                            // Inicializa a direção como zero (parado)
                            float direcao = 0;

                            // Se a diferença na altura for maior que a deadZone, decide se deve subir ou descer
                            if (Mathf.Abs(diferencaY) >= deadZone)
                            {
                                // Se o toque está acima do batedor, sobe (+1), senão desce (-1)
                                direcao = diferencaY > 0 ? 1 : -1;
                            }

                            // Envia a direção para o script de movimento
                            movimento.DefinirMovimento(direcao);

                            // Marca que já encontramos um toque válido (não precisa olhar os outros)
                            toqueValidoEncontrado = true;

                            // Interrompe o loop, já que encontramos um toque válido
                            break;
                        }
                    }
                }

                // Se nenhum toque válido foi encontrado na metade do jogador, o batedor para
                if (!toqueValidoEncontrado)
                {
                    movimento.DefinirMovimento(0);
                }
            }
            else
            {
                // Se não há toques na tela, o batedor fica parado
                movimento.DefinirMovimento(0);
            }
        }
        else
        {
            // Se não há suporte a tela sensível ao toque (ex.: no editor), o batedor fica parado
            movimento.DefinirMovimento(0);
        }
    }
}
