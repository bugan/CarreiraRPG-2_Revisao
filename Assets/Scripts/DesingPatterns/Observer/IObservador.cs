using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Padroes.Observer
{
    public interface IObservador<T>
    {
        void Notificar(object sender, T dados);
    }
}