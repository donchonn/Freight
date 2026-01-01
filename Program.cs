using System;
using System.Collections.Generic;
using System.Windows.Forms;

/* v1.1, 161109
1. https 동작안하는 버그 수정
2. 네이버 euc-kr 제거
*/

namespace Freight
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ProgramForm1());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"프로그램 시작 중 오류 발생:\n\n{ex.Message}\n\n{ex.StackTrace}",
                    "Freight 3.0 - 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
