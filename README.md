# 🏓 Jogo 2D de Pong - Unity 6

Este é um projeto desenvolvido no **Unity 6** como parte do curso de **Programação de Jogos Digitais**. O jogo é uma recriação do clássico **Pong**, permitindo que dois jogadores disputem em um ambiente simples e divertido.

---

## 🎮 Sobre o Jogo

O jogo consiste em dois jogadores controlando **batedores** para rebater a bola e impedir que ela passe para o lado adversário. O objetivo é marcar pontos quando o oponente não consegue devolver a bola.

🔹 **Modos de Jogo:** 1x1 local  
🔹 **Plataforma:** PC  
🔹 **Motor Gráfico:** Unity 6  
🔹 **Linguagem:** C#  

---

## 🛠️ Tecnologias Utilizadas

- **Unity 6** 🚀 (Motor de jogo)
- **C#** 💻 (Linguagem de programação)
- **Novo Input System** 🎮 (Para capturar comandos do jogador)
- **TextMeshPro** 📝 (Melhoria na exibição do placar)
- **Rigidbody2D** ⚡ (Física do jogo)

---

## 📂 Estrutura do Projeto

```plaintext
📦 Pong-Unity6
 ┣ 📂 Assets
 ┃ ┣ 📂 Scripts
 ┃ ┃ ┣ 📜 Batedor.cs        # Controle do jogador
 ┃ ┃ ┣ 📜 Bola.cs           # Lógica da bola e pontuação
 ┃ ┃ ┣ 📜 Placar.cs         # Controle do placar
 ┃ ┃ ┗ 📜 GameManager.cs    # Gerenciamento do jogo
 ┃ ┣ 📂 Prefabs             # Objetos pré-configurados
 ┃ ┣ 📂 Scenes              # Cenas do jogo
 ┃ ┗ 📂 UI                  # Interface gráfica
 ┗ 📜 README.md             # Este arquivo
```

---

## 🕹️ Como Jogar
- 1️⃣ O Jogador 1 usa as teclas W e S para mover o batedor.
- 2️⃣ O Jogador 2 usa as teclas Seta Para Cima e Seta Para Baixo.
- 🎯 O objetivo é rebater a bola e marcar pontos quando o oponente não conseguir defendê-la.

O jogo termina quando um dos jogadores atinge a pontuação máxima.

---

## 🚀 Como Executar o Projeto
🛠️ Pré-requisitos:
- Baixar e instalar o Unity 6
- Git instalado (opcional, caso queira clonar o repositório)

### 📥 **Clonando o Repositório**
Se deseja baixar o projeto via Git, use o seguinte comando no terminal:

```sh
git clone https://github.com/seu-usuario/pong-unity6.git
```
Ou baixe o projeto manualmente clicando no botão Download ZIP.

### ▶️ **Rodando o Jogo no Unity**
1. Abra o Unity Hub.
2. Clique em Open e selecione a pasta do projeto.
3 Aguarde o carregamento da cena inicial.
4. Pressione Play no Unity para testar o jogo.

---

## 🏗️ Estrutura do Código
### 🎮 Batedor.cs (Movimento dos jogadores)
- Utiliza Input System para capturar comandos.
- Restringe o movimento dos jogadores dentro da tela.
- Controla a velocidade de movimentação.
  
### ⚽ Bola.cs (Movimentação e lógica de pontuação)
- Define uma direção aleatória para a bola no início de cada rodada.
- Detecta colisões com os batedores e as laterais da tela.
- Adiciona pontos ao placar e reinicia o jogo quando necessário.

### 🏆 Placar.cs (Pontuação)
- Utiliza TextMeshPro para exibir o placar.
- Atualiza a pontuação quando um jogador marca um ponto.
- Verifica se algum jogador atingiu a pontuação final.

---

## 🔧 Como Contribuir
💡 Se quiser contribuir para o projeto, siga os passos abaixo:

1. Fork este repositório.
2. Clone para sua máquina local:
```sh
git clone https://github.com/seu-usuario/pong-unity6.git
```
3. Crie uma branch para a sua alteração:
```sh
git checkout -b minha-melhoria
```
4. Faça as alterações e commite:
```sh
git commit -m "Adicionei uma nova funcionalidade"
```
5. Envie as alterações:
```sh
git push origin minha-melhoria
```
6. Abra um Pull Request para revisão.

---

## 📌 Possíveis Melhorias Futuras
🔜 🚀 Algumas melhorias que podem ser adicionadas:

- ✅ Adicionar modo single-player com IA adversária.
- ✅ Criar efeitos visuais na bola e nas bordas da tela.
- ✅ Implementar trilha sonora e efeitos sonoros.
- ✅ Melhorar interface gráfica (UI) e animações.

---

## 📜 Licença
Este projeto é de código aberto e pode ser utilizado para fins educacionais.

📝 Licença MIT - Você pode modificar, distribuir e usar o código como desejar.

---

📚 Este jogo foi desenvolvido para o curso de Programação de Jogos Digitais do IFPR Telêmaco Borba
🎓 O objetivo é ensinar conceitos básicos de desenvolvimento de jogos no Unity 6 com C#.

