using StarOJ.Models;
using System;

namespace StarOJ.Client.Models
{
    public static class Utils
    {
        public static string GetMonacoLanguageId(CodeLanguage language)
        {
            return language switch
            {
                CodeLanguage.C => "c",
                CodeLanguage.CPlusPlus => "cpp",
                CodeLanguage.CSharp => "csharp",
                CodeLanguage.FSharp => "fsharp",
                CodeLanguage.Java => "java",
                CodeLanguage.Javascript => "javascript",
                CodeLanguage.Python => "python",
                CodeLanguage.Shell => "shell",
                CodeLanguage.Ruby => "ruby",
                CodeLanguage.Rust => "rust",
                CodeLanguage.Swift => "swift",
                CodeLanguage.Typescript => "typescript",
                _ => throw new NotImplementedException(),
            };
        }
    }
}
