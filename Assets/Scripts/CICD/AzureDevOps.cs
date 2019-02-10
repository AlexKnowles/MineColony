using System;
using UnityEditor;

namespace MineColony.CICD
{
    public class AzureDevOps
    {
        private static readonly string[] _scenes =
        {
            "Assets/Scenes/SampleScene.unity"
        };

        [MenuItem("CICD/Build Game")]
        public static void Build()
        {
            string buildOutputDirectory = GetCommandLineArgumentValue("BuildOutputDirectory");

            BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = _scenes,
                target = EditorUserBuildSettings.activeBuildTarget,
                locationPathName = buildOutputDirectory,
                targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup,
            });
        }

        private static string GetCommandLineArgumentValue(string argumentName)
        {
            string[] allArguments = Environment.GetCommandLineArgs();

            if (!argumentName.StartsWith("--"))
            {
                argumentName = ("--" + argumentName);
            }

            for (int i = 0; i < allArguments.Length; i++)
            {
                if (allArguments[i] == argumentName)
                {
                    return allArguments[i + 1];
                }
            }

            throw new Exception("The argument '" + argumentName + "' could not be found");
        }
    }
}
