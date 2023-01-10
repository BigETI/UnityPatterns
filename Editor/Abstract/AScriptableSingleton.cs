using UnityEditor;
using UnityEngine;

/// <summary>
/// Unity Patterns editor scriptable singletons namespace
/// </summary>
namespace UnityPatternsEditor.ScriptableSingletons
{
    /// <summary>
    /// A class that describes a scriptable singleton
    /// </summary>
    /// <typeparam name="TScriptableObject">Scriptable object</typeparam>
    public abstract class AScriptableSingleton<TScriptableObject> :
        ScriptableSingleton<TScriptableObject>,
        IScriptableSingleton<TScriptableObject>
        where TScriptableObject : ScriptableObject
    {
        // ...
    }
}
