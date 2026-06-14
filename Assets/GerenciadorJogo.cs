using UnityEngine;

public class GerenciadorJogo : MonoBehaviour
{
    public Renderer corJogador;
    private bool jogoIniciado = false;

    // Essa função desenha o Menu direto na tela, sem precisar de Canvas!
    void OnGUI()
    {
        if (!jogoIniciado)
        {
            // Cria um fundo escuro
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

            // Cria o botão JOGAR bem no meio da tela
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 60), "JOGAR"))
            {
                jogoIniciado = true; // Quando clica, o jogo começa!
            }
        }
    }

    void Update()
    {
        // Se o jogo começou e apertar C, muda a cor
        if (jogoIniciado && Input.GetKeyDown(KeyCode.C))
        {
            if (corJogador != null)
            {
                corJogador.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}