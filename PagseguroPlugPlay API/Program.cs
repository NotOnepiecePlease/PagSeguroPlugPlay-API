using System;
using System.Windows.Forms;
using PagseguroPlugPlay_API.Forms;

namespace PagseguroPlugPlay_API
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Inicial());
        }
    }
}