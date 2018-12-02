﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class CameraBehavior : MonoBehaviour
{
	public void Start ()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                MathGOUtils.FirebaseApp = Firebase.FirebaseApp.DefaultInstance;
                MathGOUtils.FirebaseReady = true;
                MathGOUtils.FirebaseApp.SetEditorDatabaseUrl("");

                MathGOUtils.DataBase = FirebaseDatabase.DefaultInstance.RootReference;

                /*for (int i = 1; i <= 12; i++)
                {
                    Equipe equipe = new Equipe("Equipe " + i, "Peroba", false);

                    Membro member1 = new Membro();
                    member1.name = "Jader Antonio Tomelin";

                    Membro member2 = new Membro();
                    member2.name = "Flávio Omar Losada";

                    Membro member3 = new Membro();
                    member3.name = "Matheus Eduardo Hoeltgebaum Pereira";

                    equipe.members.Add(member1);
                    equipe.members.Add(member2);
                    equipe.members.Add(member3);

                    equipe.Key = "equipe" + i;
                    string json = JsonUtility.ToJson(equipe);

                    MathGOUtils.DataBase.Child("equipes").Child(equipe.Key).SetRawJsonValueAsync(json);
                }*/

                //Buscar todas equipes
                FirebaseDatabase.DefaultInstance
                .GetReference("equipes")
                .GetValueAsync().ContinueWith(task2 => {
                    if (task2.IsFaulted)
                    {
                        // Handle the error...
                    }
                    else if (task2.IsCompleted)
                    {
                        DataSnapshot snapshot = task2.Result;

                        foreach (DataSnapshot node in snapshot.Children)
                        {
                            Equipe equipe = JsonUtility.FromJson<Equipe>(node.GetRawJsonValue());
                            equipe.Key = node.Key;

                            MathGOUtils.mapEquipes.Add(node.Key, equipe);
                        }

                        //Fazer tela no canvas e devolver o carinha que for validado...

                        MathGOUtils.mapEquipes.TryGetValue("equipe1", out MathGOUtils.EquipeSelecionada);

                        MathGOUtils.EquipeSelecionada.Ativa = true;
                        MathGOUtils.ModificaEquipe(MathGOUtils.EquipeSelecionada);
                    }
                });
            }
            else
            {
                Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }
	
	public void Update ()
    {
		
	}
}
