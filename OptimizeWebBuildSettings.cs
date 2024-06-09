// https://docs.unity3d.com/6000.0/Documentation/Manual/web-optimization.html
// https://docs.unity3d.com/6000.0/Documentation/Manual/web-optimization-mobile.html

// Place this script in Assets/Editor folder
#if UNITY_WEBGL
using UnityEditor;
using UnityEditor.Build;

public class MenuOptimizeWebBuildSettings
{
    [MenuItem("Tools/Optimize Web Build Settings")]
    public static void OptimizeWebBuildSettings()
    {
        var namedBuildTarget = NamedBuildTarget.WebGL;

        //// Platform Settings \\\\

        // Set Platform Settings to optimize for disk size (LTO)
        EditorUserBuildSettings.SetPlatformSettings(
            namedBuildTarget.TargetName,
            "CodeOptimization",
            "DiskSizeLTO"
        );

        //// Other Settings \\\\

        // PlayerSettings.SetApiCompatibilityLevel(namedBuildTarget, ApiCompatibilityLevel.NET_2_0);
        PlayerSettings.SetIl2CppCodeGeneration(namedBuildTarget, Il2CppCodeGeneration.OptimizeSize);
        PlayerSettings.SetIl2CppCompilerConfiguration(
            namedBuildTarget,
            Il2CppCompilerConfiguration.Master
        );
        PlayerSettings.stripEngineCode = true;
        PlayerSettings.SetManagedStrippingLevel(namedBuildTarget, ManagedStrippingLevel.High);

        //// Publishing Settings \\\\

        // PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Brotli;
        PlayerSettings.WebGL.nameFilesAsHashes = true;
        PlayerSettings.WebGL.dataCaching = true;
        PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.Off;
        // PlayerSettings.WebGL.exceptionSupport = WebGLExceptionSupport.None;
        PlayerSettings.WebGL.wasm2023 = true;
        // PlayerSettings.WebGL.webAssemblyTable = true;
        // PlayerSettings.WebGL.webAssemblyBigInt = true;
    }
}
#endif
