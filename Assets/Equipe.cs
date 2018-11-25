using System;
using System.Collections.Generic;

[Serializable]
public class Equipe
{
    public string Key { get; set; }
    public string Nome;
    public bool Ativa;
    public List<Marcador> Marcadores = new List<Marcador>();

    public Equipe()
    {
    }

    public Equipe(string Nome, bool Ativa)
    {
        this.Nome = Nome;
        this.Ativa = Ativa;
    }
}