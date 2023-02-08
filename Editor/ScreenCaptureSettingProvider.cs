using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class ScreenCaptureSettingProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Screen Capture";

        private Editor m_editor;

        private ScreenCaptureSettingProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = ScreenCaptureSetting.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            var setting = ScreenCaptureSetting.instance;

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            setting.Save();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new ScreenCaptureSettingProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}