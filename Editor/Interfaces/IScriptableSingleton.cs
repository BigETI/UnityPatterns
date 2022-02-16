using UnityEngine;

/// <summary>
/// Unity Patterns editor namespace
/// </summary>
namespace UnityPatternsEditor
{
    /// <summary>
    /// An interface that represents a scriptable singleton
    /// </summary>
    /// <typeparam name="T">Scriptable object type</typeparam>
    public interface IScriptableSingleton<T> : UnityEditorInterfaces.IScriptableSingleton<T> where T : ScriptableObject
    {
        // ...
    }
}
