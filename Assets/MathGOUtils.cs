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
    public static Dictionary<string, Equipe> mapEquipes = new Dictionary<string, Equipe>();
    public static Equipe EquipeSelecionada;
    public static bool ReadyToChooseTeam = false;

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

    public static bool FindTeamByMarkerName(string MarkerName)
    {
        if (mapEquipes.TryGetValue(ConvertMarkerNameToDatabaseName(MarkerName), out EquipeSelecionada))
        {
            EquipeSelecionada.Ativa = true;
            ModificaEquipe(EquipeSelecionada);
            return true;
        }

        return false;
    }
    
    private static string ConvertMarkerNameToDatabaseName(string MarkerName)
    {
        switch (MarkerName)
        {
            case "Grupo1" : return "equipe1" ;
            case "Grupo2" : return "equipe2" ;
            case "Grupo3" : return "equipe3" ;
            case "Grupo4" : return "equipe4" ;
            case "Grupo5" : return "equipe5" ;
            case "Grupo6" : return "equipe6" ;
            case "Grupo7" : return "equipe7" ;
            case "Grupo8" : return "equipe8" ;
            case "Grupo9" : return "equipe9" ;
            case "Grupo10": return "equipe10";
            case "Grupo11": return "equipe11";
            case "Grupo12": return "equipe12";
            default: return "";
        }
    }
}
