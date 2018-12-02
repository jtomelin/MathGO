using System;
using System.Collections.Generic;

[Serializable]
public class Equipe
{
    public string Key { get; set; }
    public string Nome;
    public string editableName;
    public bool Ativa;
    public List<Marcador> Marcadores = new List<Marcador>();
    public List<Membro>   members    = new List<Membro>();

    public Equipe()
    {
    }

    public Equipe(string Nome, string editableName, bool Ativa)
    {
        this.Nome         = Nome;
        this.editableName = editableName;
        this.Ativa        = Ativa;
    }
}