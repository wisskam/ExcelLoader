using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ExcelLoader.Class
{
    public static class FileLoader
    {
        public static DataTable FileDataTable = new DataTable();
        public static DataTable FileDataTableSchema = new DataTable();
        public static string FilePath;
        public static int CurrentTableIndex = -1; 
        public static string CurrentFileGroup; 

        public static List<FileType> AllowedFileType = new List<FileType>
        {
            new FileType("excel", "xlsx"),
            new FileType("excel", "xls"),
            new FileType("csv", "csv")
        };

        public static void Initialize(string[] args)
        {
            if (args.Length > 0)
                FilePath = args[0];
            
            else
                return;
            
            if (args[0] == "")
                return;

            CurrentFileGroup = GetFileGroupByType(FilePath.Substring(FilePath.LastIndexOf('.') + 1));

            if (CurrentFileGroup == "excel")
            {
                HandleExcel();
            }

            else if (CurrentFileGroup == "csv")
            {

            }

            else
            {
                throw new FileFormatException("Incorrect file type!");
            }
        }

        public static void HandleCSV()
        {


        }

        public static void HandleExcel()
        {
            string connectionString = string.Format(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties=\"Excel 12.0;HDR=YES;\"", 
                FilePath.Substring(FilePath.LastIndexOf("\'") + 1)
            );

            OLEDBHelper oledbHelper = new OLEDBHelper(connectionString);

            FileDataTableSchema = oledbHelper.GetOleDbSchemaTable();

            if (FileDataTableSchema.Rows.Count < 1)
            {
                throw new FileLoaderNoRowsException();
            }

            if (CurrentTableIndex == -1)
            {
                CurrentTableIndex = 0;
            }

            FileDataTable = oledbHelper.Query("select * from [" + FileDataTableSchema.Rows[CurrentTableIndex]["TABLE_NAME"].ToString() + "]");

        }

        public static string GetFileGroupByType(string searchedFileType)
        {
            FileType matchingFileType = AllowedFileType.FirstOrDefault(fileType => fileType.Type == searchedFileType);
            return matchingFileType.Group;
        }

        public static string GetFileName()
        {
            if (FilePath != "")
                return FilePath.Substring(
                    FilePath.LastIndexOf('\\')+1,
                    FilePath.LastIndexOf('.') - (FilePath.LastIndexOf('\\')+1)
                );
            else
                return "";
        }

        public class FileType
        {

            public string Group;
            public string Type;

            public FileType(string group, string type)
            {
                this.Group = group;
                this.Type = type;
            }

        }

    }
}
