using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Freight.Models;

namespace Freight.Services
{
    /// <summary>
    /// JSON 기반 설정 관리 클래스
    /// </summary>
    public class ConfigManager
    {
        private static ConfigManager instance;
        private static readonly object lockObject = new object();

        private string configFilePath;
        private AppSettings settings;

        private ConfigManager()
        {
            configFilePath = Path.Combine(Application.StartupPath, "config.json");
            LoadSettings();
        }

        /// <summary>
        /// 싱글톤 인스턴스
        /// </summary>
        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new ConfigManager();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 현재 설정
        /// </summary>
        public AppSettings Settings
        {
            get { return settings; }
        }

        /// <summary>
        /// 설정 로드
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    string json = File.ReadAllText(configFilePath);
                    settings = JsonConvert.DeserializeObject<AppSettings>(json);

                    if (settings == null || settings.Commands == null)
                    {
                        settings = new AppSettings();
                    }
                }
                else
                {
                    // 설정 파일이 없으면 기본 설정 생성
                    settings = new AppSettings();
                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 로드 중 오류 발생: {ex.Message}\n기본 설정을 사용합니다.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                settings = new AppSettings();
            }
        }

        /// <summary>
        /// 설정 저장
        /// </summary>
        public void SaveSettings()
        {
            try
            {
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(configFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 저장 중 오류 발생: {ex.Message}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 설정 다시 로드
        /// </summary>
        public void ReloadSettings()
        {
            LoadSettings();
        }

        /// <summary>
        /// 명령어 찾기
        /// </summary>
        public CommandItem FindCommand(string commandName)
        {
            return settings.FindCommand(commandName);
        }

        /// <summary>
        /// 명령어 추가
        /// </summary>
        public void AddCommand(CommandItem command)
        {
            settings.AddCommand(command);
            SaveSettings();
        }

        /// <summary>
        /// 명령어 제거
        /// </summary>
        public bool RemoveCommand(string commandName)
        {
            bool result = settings.RemoveCommand(commandName);
            if (result)
            {
                SaveSettings();
            }
            return result;
        }

        /// <summary>
        /// 엑셀 파일에서 JSON으로 마이그레이션
        /// </summary>
        public void MigrateFromExcel(string excelPath)
        {
            // 기존 Excel 데이터를 JSON으로 변환하는 로직
            // EPPlus를 사용하여 엑셀 파일 읽기
            // 이 부분은 나중에 필요시 구현
        }
    }
}
