using System;
using System.Diagnostics;
using System.Windows.Forms;
using Freight.Models;

namespace Freight
{
    /// <summary>
    /// 명령어 실행 클래스
    /// </summary>
    class Run
    {
        private string path;

        public Run(Analyze az)
        {
            string commandString = az.commandString;
            string searchString = az.searchString;
            CommandItem command = az.command;

            // 종료 명령어 처리
            if (commandString.StartsWith("꺼져") || commandString.StartsWith("종료") || commandString.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Application.Exit();
                return;
            }

            // 직접 URL 입력
            if (commandString.StartsWith("http://") || commandString.StartsWith("https://"))
            {
                this.path = commandString;
            }
            else if (command != null)
            {
                // 명령어 찾음
                this.path = command.Path + searchString;

                // URL 정리 로직
                if (string.IsNullOrEmpty(searchString) && this.path.StartsWith("http"))
                {
                    // 검색어가 없고 URL인 경우
                    if (!this.path.EndsWith("aspx") && commandString != "w")
                    {
                        // 도메인만 추출
                        try
                        {
                            Uri uri = new Uri(this.path);
                            this.path = uri.Scheme + "://" + uri.Host;
                        }
                        catch
                        {
                            // URI 파싱 실패 시 원래 경로 사용
                        }
                    }
                }
            }
            else
            {
                // 명령어를 찾지 못한 경우
                MessageBox.Show($"명령어 '{commandString}'를 찾을 수 없습니다.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 실행
            ExecuteCommand();
        }

        private void ExecuteCommand()
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                Process ps = new Process();
                ps.StartInfo.FileName = this.path;
                ps.StartInfo.UseShellExecute = true;
                ps.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"프로그램 실행 실패: {ex.Message}\n경로: {this.path}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예기치 않은 오류 발생: {ex.Message}\n경로: {this.path}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
