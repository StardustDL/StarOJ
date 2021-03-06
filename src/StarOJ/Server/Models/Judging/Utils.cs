﻿using Judge0.Models;
using StarOJ.Models;
using StarOJ.Models.Judging;
using System.Collections.Generic;

namespace StarOJ.Server.Models.Judging
{
    internal static class Utils
    {
        static Dictionary<CodeLanguage, int> LanguageToId;

        static Dictionary<int, CodeLanguage> IdToLanguage;

        static void InitializeLanguageToId()
        {
            static void Add(CodeLanguage lang, int id)
            {
                LanguageToId.Add(lang, id);
                IdToLanguage.Add(id, lang);
            }

            LanguageToId = new Dictionary<CodeLanguage, int>();
            IdToLanguage = new Dictionary<int, CodeLanguage>();

            Add(CodeLanguage.C, 50);
            Add(CodeLanguage.CPlusPlus, 54);
            Add(CodeLanguage.Ruby, 72);
            Add(CodeLanguage.Rust, 73);
            Add(CodeLanguage.CSharp, 51);
            Add(CodeLanguage.FSharp, 87);
            Add(CodeLanguage.Java, 62);
            Add(CodeLanguage.Javascript, 63);
            Add(CodeLanguage.Python, 71);
            Add(CodeLanguage.Shell, 46);
            Add(CodeLanguage.Swift, 83);
            Add(CodeLanguage.Typescript, 74);
        }

        public static int GetLanguageId(CodeLanguage language)
        {
            if (LanguageToId is null)
                InitializeLanguageToId();
            return LanguageToId[language];
        }

        public static CodeLanguage GetLanguage(int id)
        {
            if (IdToLanguage is null)
                InitializeLanguageToId();
            return IdToLanguage[id];
        }

        public static Submission ToJudge0Submission(this JudgingTask task)
        {
            return new Submission
            {
                token = task.Id,
                language_id = GetLanguageId(task.Language),
                source_code = task.Code,
                stdin = task.StandardInput,
                stdout = task.StandardOutput,
                stderr = task.StandardError,
                compile_output = task.CompileOutput,
            };
        }

        public static JudgingTask ToJudgingTask(this Submission submission)
        {
            return new JudgingTask
            {
                Id = submission.token,
                Language = Utils.GetLanguage(submission.language_id.Value),
                StandardInput = submission.stdin,
                StandardOutput = submission.stdout,
                StandardError = submission.stderr,
                CompileOutput = submission.compile_output,
                Code = submission.source_code,
            };
        }
    }
}
