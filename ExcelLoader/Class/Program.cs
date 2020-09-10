using System;
using System.Windows.Forms;
using ExcelLoader.Class;
using Microsoft.Win32;

namespace ExcelLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            RegisterContextMenu();

            //args = new string[] { Path.Combine("C:\\Users\\Kubeu\\Desktop\\sampleExcel.xlsx") };
            //args = new string[] { Path.Combine("C:\\Users\\Kubeu\\Desktop\\sample Empty Excel2.xlsx") };
            //args = new string[] { Path.Combine("C:\\Users\\Kubeu\\Desktop\\Nowy Arkusz programu Microsoft Excel.xlsx") };


            try
            {
                // Set filename on 0 and parameter on 1 
                // (when file has spaces in name, original args have multiple records with splitted file name
                args = ProcessFileArguments(args);

                // Load all defined database connections
                ConnectionList.Load();

                // Get path from argument and load a preview of file if exists
                FileLoader.Initialize(args);
            }
            catch (FileLoaderNoRowsException ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new Form1(args));
        
        }

        // Add program to system registry to allow right-click access directly on file
        static void RegisterContextMenu()
        {
            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Excel.Sheet.12\shell\ExcelLoader\command");
                
                //Check for xlsx
                if (key == null)
                {
                    key = Registry.ClassesRoot.CreateSubKey(@"Excel.Sheet.12\shell\ExcelLoader");
                    key.SetValue("NoWorkingDirectory", "");
                    key = Registry.ClassesRoot.CreateSubKey(@"Excel.Sheet.12\shell\ExcelLoader\command");
                    key.SetValue("", Application.ExecutablePath + " \"\"%V\"\"");
                }

                key = Registry.ClassesRoot.OpenSubKey(@"Excel.Sheet.8\shell\ExcelLoader\command");

                //Check for xls
                if (key == null)
                {
                    key = Registry.ClassesRoot.CreateSubKey(@"Excel.Sheet.8\shell\ExcelLoader");
                    key.SetValue("NoWorkingDirectory", "");
                    key = Registry.ClassesRoot.CreateSubKey(@"Excel.Sheet.8\shell\ExcelLoader\command");
                    key.SetValue("", Application.ExecutablePath + " \"\"%V\"\"");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        static string[] ProcessFileArguments(string[] args)
        {
            string fileName = "";
            bool noPreview = false;
            
            for (int i = 0; i < args.Length; i++)
            { 
                // Breaks when nopreview argument provided
                // (program executed from file context)
                if (args[i] == "-nopreview")
                    break;

                fileName += args[i];

                if (i < args.Length - 1)
                    fileName += ' ';
            }

            string[] args2 = { "", "" };
            
            args2[0] = fileName;
            args2[1] = noPreview ? "1" : "0";
            
            return args2;

        }
    }

}
