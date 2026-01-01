using System;
using Freight.Models;
using Freight.Services;

namespace Freight
{
    /// <summary>
    /// 명령어 분석 클래스
    /// </summary>
    class Analyze
    {
        public string commandString; // 명령어
        public string searchString;  // 검색어
        public CommandItem command;  // 찾은 명령어 항목

        private ConfigManager configManager;

        public Analyze(string str)
        {
            configManager = ConfigManager.Instance;

            string[] split = null;
            char[] sep = { ' ' };
            split = str.Split(sep, 2);

            if (split.Length == 2)
            {
                this.commandString = split[0]; // 명령어
                this.searchString = split[1];  // 검색어
            }
            else if (split.Length == 1)
            {
                this.commandString = str;
                this.searchString = "";
            }
            else
            {
                this.commandString = "";
                this.searchString = "";
            }

            // 불필요한 문자 제거
            this.commandString = this.commandString.Replace("'", "").Trim();
            this.searchString = this.searchString.Replace("'", "").Trim();

            // 명령어 찾기
            FindCommand();
        }

        private void FindCommand()
        {
            // 명령어 검색
            command = configManager.FindCommand(commandString);

            // 명령어를 찾지 못한 경우 DEFAULT 명령어 사용
            if (command == null)
            {
                searchString = commandString + " " + searchString;
                commandString = "DEFAULT";
                command = configManager.FindCommand("DEFAULT");
            }
        }
    }
}
