using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotifyLoginMenu : MonoBehaviour {

    public Text spotifyLoginText;
    public InputField nomeDeUsuarioInputField;
    public InputField senhaInputField;
    public Button entrarButton;
    private string nomeDeUsuario;
    private string senha;


    void Start()
    {
        entrarButton.onClick.AddListener(TaskOnClick);
        entrarButton.onClick.AddListener(setNomeDeUsuario);
        entrarButton.onClick.AddListener(setSenha);

    }

    private void setNomeDeUsuario()
    {
        nomeDeUsuario = nomeDeUsuarioInputField.text;
    }

    private void setSenha()
    {
        senha = senhaInputField.text;
    }

    public string getNomeDeUsuario()
    {
        return nomeDeUsuario;
    }

    public string getSenha()
    {
        return senha;
    }

    void TaskOnClick()
    {
        //saida no console quando entrar for clicado
        Debug.Log("Você apertou o botão entrar!");
    }
}
