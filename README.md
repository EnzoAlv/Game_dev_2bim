# Cubo Néon: O Jogo

**Descrição:** Cubo Néon é um jogo 3D minimalista focado na movimentação física do personagem principal. O projeto foi desenvolvido de raiz no Unity para a entrega do 2º Bimestre, priorizando a estabilidade mecânica, interface via código e física de colisão.

**Instruções de Jogabilidade:**
- **Teclas WASD** - Movimentam o cubo pelo cenário.
- **Barra de Espaço** - Aciona o salto do personagem (com verificação de colisão).
- **Tecla C** - Altera o aspeto visual do cubo com uma nova cor RGB aleatória.

---
🎵 Funcionalidade Bônus: Trilha Sonora Original
Para complementar o design minimalista do jogo com uma imersão mais forte, o ambiente possui uma música de fundo contínua. A faixa utilizada é uma produção musical da minha autoria, focada na estrutura e vibração do funk submundo. A batida e o alinhamento foram inteiramente desenvolvidos e misturados por mim e um amigo no FL Studio. 
A faixa completa encontra-se disponível no meu perfil do Spotify!

🎧 Ouça no Spotify: https://open.spotify.com/intl-pt/track/78egRNN7B5j1Fp8YZIoVvk?si=e59602ae12fc4e9e

### 🎥 Gameplay
<img width="883" height="874" alt="Captura de tela 2026-06-14 202528" src="https://github.com/user-attachments/assets/ae802d67-8986-41be-9ad3-7446c731f828" />


---

### 🖼️ Capturas de Ecrã do Jogo

**1. Ecrã Inicial (Menu via código OnGUI)**

<img width="883" height="874" alt="Captura de tela 2026-06-14 202528" src="https://github.com/user-attachments/assets/5c232419-a1e8-467e-a768-88461fec8171" />

**2. Gameplay - Movimentação pelo cenário**
<img width="877" height="872" alt="image" src="https://github.com/user-attachments/assets/36f0ccc0-c91d-404f-8db0-646fae25e511" />


**3. Gameplay - Sistema de Cores**
<img width="875" height="871" alt="image" src="https://github.com/user-attachments/assets/658fc6ec-b0cc-4f4a-9cfd-0d30d5518db5" />



---

### 💻 Funcionalidades Desenvolvidas

Abaixo estão detalhadas as implementações originais feitas no projeto:

#### 1. Sistema de Cores e Interface Dinâmica (OnGUI)
Para o ecrã inicial do jogo e customização do personagem, optei por criar um menu via código utilizando o método `OnGUI` do Unity, dispensando o uso do Canvas padrão. O script gera um botão centralizado que liberta o início do jogo. Após iniciado, a tecla 'C' acede ao renderizador do jogador e aplica uma cor aleatória.

```csharp
    void OnGUI()
    {
        if (!jogoIniciado)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), "JOGAR"))
            {
                jogoIniciado = true;
            }
        }
    }

    void Update()
    {
        if (jogoIniciado && Input.GetKeyDown(KeyCode.C))
        {
            if (corJogador != null)
            {
                corJogador.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
```
2. Física de Salto com Rigidbody Limitado
O sistema de movimentação utiliza leitura de inputs horizontais e verticais em tempo real. Para o salto, implementei uma verificação matemática da velocidade do eixo Y (Mathf.Abs(rb.velocity.y) < 0.01f). 
Isto garante que o jogador só consiga aplicar a força de impulso (ForceMode.Impulse) se o cubo estiver completamente encostado ao chão, evitando bugs de saltos infinitos no ar.

````C#
void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movX, 0, movZ) * velocidade * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
    }

````


