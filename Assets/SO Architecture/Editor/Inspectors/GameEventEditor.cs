﻿using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using UnityEditor;
using UnityEngine;

namespace DanielEverland.ScriptableObjectArchitecture.Editor.Inspectors
{
    [CustomEditor(typeof(GameEventBase), true)]
    public sealed class GameEventEditor : BaseGameEventEditor
    {
        private GameEvent Target { get { return (GameEvent)target; } }

        protected override void DrawRaiseButton()
        {
            if (GUILayout.Button("Raise"))
            {
                Target.Raise();
            }
        }
    }
}