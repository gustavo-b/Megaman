using System;
using UnityEngine;
using UnityEngine.UI;

public class SpotifyLoginMenu : MonoBehaviour {

    public Text spotifyLoginText;
    public InputField nomeDeUsuarioInputField;
    public InputField senhaInputField;
    public Button entrarButton;
    private string nomeDeUsuario;
    private string senha;
    private Boolean logado;


    void Start()
    {
        entrarButton.onClick.AddListener(TaskOnClick);
        entrarButton.onClick.AddListener(setNomeDeUsuario);
        entrarButton.onClick.AddListener(setSenha);
        entrarButton.onClick.AddListener(setLogado);

    }

    private void setNomeDeUsuario()
    {
        nomeDeUsuario = nomeDeUsuarioInputField.text;
    }

    private void setSenha()
    {
        senha = senhaInputField.text;
    }

    public void setLogado ()
    {
        logado = true;
        Debug.Log("logado com sucesso");
    }

    public string getNomeDeUsuario()
    {
        return nomeDeUsuario;
    }

    public string getSenha()
    {
        return senha;
    }

    public Boolean isLogado ()
    {
        return logado;
    }

    void TaskOnClick()
    {
        //saida no console quando entrar for clicado
        Debug.Log("Você apertou o botão entrar!");
    }
}
