﻿using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Type = System.Type;

namespace DanielEverland.ScriptableObjectArchitecture.Editor.Inspectors
{
    [CustomEditor(typeof(GameEventBase<>), true)]
    public class TypedGameEventEditor : BaseGameEventEditor
    {
        private Type GenericType { get { return target.GetType().BaseType.GetGenericArguments()[0]; } }

        private MethodInfo _raiseMethod;

        protected override void OnEnable()
        {
            base.OnEnable();

            _raiseMethod = target.GetType().BaseType.GetMethod("Raise", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        }
        protected override void DrawRaiseButton()
        {
            SerializedProperty property = serializedObject.FindProperty("_debugValue");

            EditorGUILayout.PropertyField(property);

            if (GUILayout.Button("Raise"))
            {
                CallMethod(GetDebugValue(property));
            }
        }
        private object GetDebugValue(SerializedProperty property)
        {
            object parent = SerializedPropertyHelper.GetParent(property);
            Type parentType = parent.GetType();

            FieldInfo targetField = parentType.GetField("_debugValue", BindingFlags.Instance | BindingFlags.NonPublic);

            return targetField.GetValue(parent);
        }
        private void CallMethod(object value)
        {
            _raiseMethod.Invoke(target, new object[1] { value });
        }
    }
}