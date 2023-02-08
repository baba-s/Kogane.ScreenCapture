using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ScreenCaptureSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ScreenCaptureSetting : ScriptableSingleton<ScreenCaptureSetting>
    {
        [SerializeField] private string m_directoryName  = "Kogane.ScreenCaptureMenuItem";
        [SerializeField] private string m_fileNameFormat = "yyyy-MM-dd_HHmmss";

        public string DirectoryName  => m_directoryName;
        public string FileNameFormat => m_fileNameFormat;

        public void Save()
        {
            Save( true );
        }
    }
}