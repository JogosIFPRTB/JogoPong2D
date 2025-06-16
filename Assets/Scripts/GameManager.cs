using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe responsável pelo controle geral do jogo.
/// Gerencia placares, limites da tela, reinício e fim do jogo.
/// Implementa o padrão Singleton para garantir que haja
/// apenas uma instância ativa no jogo.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Acesso global (Singleton)

    // Limites da tela no mundo (esquerda inferior e direita superior)
    public Vector2 emBaixoEsquerda { get; private set; }
    public Vector2 emCimaDireita { get; private set; }

    [Header("Configurações do Jogo")]
    public int pontuacaoFinal = 5; // Pontuação necessária para vencer

    [Header("Referências")]
    public Placar placarEsquerda; // Placar do jogador da esquerda
    public Placar placarDireita;  // Placar do jogador da direita
    public Bola bola;             // Referência à bola do jogo

    private bool jogoPausado = false; // Indica se o jogo está pausado

    private void Awake()
    {
        // Implementação do Singleton para garantir uma única instância
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Calcula os limites da tela com base na câmera principal
        CalculaLimitesDaTela();

        // Inicia a bola no centro do campo
        bola.IniciarBola();
    }

    /// <summary>
    /// Calcula os limites da tela no espaço do mundo
    /// </summary>
    private void CalculaLimitesDaTela()
    {
        emBaixoEsquerda = Camera.main.ScreenToWorldPoint(Vector2.zero);
        emCimaDireita = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    /// <summary>
    /// Incrementa ponto para o jogador e verifica se ele venceu.
    /// </summary>
    public void RegistrarPonto(Placar placar)
    {
        placar.somaPonto();

        if (placar.verificaPonto() >= pontuacaoFinal)
        {
            FimDeJogo();
        }
        else
        {
            bola.ReiniciarBola();
        }
    }

    /// <summary>
    /// Finaliza o jogo, pausando o tempo.
    /// </summary>
    private void FimDeJogo()
    {
        Debug.Log("Fim de Jogo!");
        jogoPausado = true;
        Time.timeScale = 0f; // Pausa o jogo
    }

    /// <summary>
    /// Reinicia o jogo, resetando placares e bola.
    /// </summary>
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        jogoPausado = false;
        placarEsquerda.Resetar();
        placarDireita.Resetar();
        bola.ReiniciarBola();
    }

    public bool EstaPausado()
    {
        return jogoPausado;
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
