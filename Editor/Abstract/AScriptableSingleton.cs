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
    /// <typeparam name="T"></typeparam>
    public abstract class AScriptableSingleton<T> : ScriptableSingleton<T>, IScriptableSingleton<T> where T : ScriptableObject
    {
        // ...
    }
}
