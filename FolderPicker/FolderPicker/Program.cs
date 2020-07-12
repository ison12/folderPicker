using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderPicker
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var args = Environment.GetCommandLineArgs();

            string title = args[1].Trim('"');
            string InitialDir = args[2].Trim('"');
            string outpuFile = args[3].Trim('"');

            if (string.IsNullOrEmpty(title))
            {
                title = "フォルダ選択";
            }

            var dialog = new CommonOpenFileDialog(title);
            dialog.IsFolderPicker = true; // フォルダ選択
            dialog.InitialDirectory = InitialDir;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var selectedDirPath = dialog.FileName;

                if (!Directory.Exists(Path.GetDirectoryName(outpuFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outpuFile));
                }

                File.WriteAllText(outpuFile, selectedDirPath);
            }
        }
    }
}
