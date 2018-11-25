using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using UnityEngine;

public static class MathGOUtils
{
    public static string LastTrackableName { get; set; }
    public static FirebaseApp FirebaseApp;
    public static DatabaseReference DataBase;
    public static bool FirebaseReady = false;
    public static Dictionary<string, Equipe> mapEquipes = new Dictionary<string, Equipe>(); //A principio eu ia barrar equipes que ja estao ativas nao permitir entrar em outro celular, porem mudei de ideia
    public static Equipe EquipeSelecionada;

    public static void ModificaEquipe(Equipe equipe)
    {
        string json = JsonUtility.ToJson(equipe);
        DataBase.Child("equipes").Child(equipe.Key).SetRawJsonValueAsync(json);
    }

    public static bool MarcadorRespondido(string MarkerName)
    {
        if (EquipeSelecionada == null)
            return false;

        for (int iMarcador = 0; iMarcador < EquipeSelecionada.Marcadores.Count; iMarcador++)
        {
            if (EquipeSelecionada.Marcadores[iMarcador].MarkerName == MarkerName)
                return EquipeSelecionada.Marcadores[iMarcador].Respondido;
        }

        return false;
    }
}
