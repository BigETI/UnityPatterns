using UnityEngine;

/// <summary>
/// Unity Patterns editor namespace
/// </summary>
namespace UnityPatternsEditor
{
    /// <summary>
    /// An interface that represents a scriptable singleton
    /// </summary>
    /// <typeparam name="TScriptableObject">Scriptable object type</typeparam>
    public interface IScriptableSingleton<TScriptableObject> :
        UnityEditorInterfaces.IScriptableSingleton<TScriptableObject>
        where TScriptableObject : ScriptableObject
    {
        // ...
    }
}
