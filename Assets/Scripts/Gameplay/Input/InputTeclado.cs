using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Input;

public class InputTeclado : MonoBehaviour {
    [SerializeField]
    private InputAction botaoAtaque;


    [SerializeField]
    private InputAction botoesDirecionais;
    
    [SerializeField]
    private MeuEventoVec2 botaoDirecionalApertado;
    [SerializeField]
    private UnityEvent botaoDeAtaqueApertado;

     void Awake()
    {
        botaoAtaque.performed += Atacar;
        botoesDirecionais.performed += Andar;
    }

    private void Andar(InputAction.CallbackContext contexto)
    {
        var dir = contexto.ReadValue<Vector2>();
        this.botaoDirecionalApertado.Invoke(dir);
    }

    private void Atacar(InputAction.CallbackContext contexto)
    {
        this.botaoDeAtaqueApertado.Invoke();
    }

    void OnEnable()
    {
        botaoAtaque.Enable();
        botoesDirecionais.Enable();
    }

    void OnDisable()
    {
        botaoAtaque.Disable();
        botoesDirecionais.Disable();
    }
}

[Serializable]
public class MeuEventoVec2 : UnityEvent<Vector2> { }