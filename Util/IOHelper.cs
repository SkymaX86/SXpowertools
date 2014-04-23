using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;

using SXpowertools.Extensions;
using System.Diagnostics;

namespace SXpowertools.Util
{
    public static class IOHelper
    {
        #region Files and Directories
        /// <summary>
        /// <para>DE: Alle Verzeichnisse im pfad werden erstellt wenn createPath = true.</para>
        /// <para>EN: Any and all directories specified in path are created if createPath = true.</para>
        /// </summary>
        /// <param name="path">the path</param>
        /// <param name="createPath">true=all paths would be createt | false=throw Exception if path not exists</param>
        /// <returns>the created path</returns>
        public static string ForceDirectories(string path, bool createPath)
        {
            if (!path.EndsWith(@"\"))
                path += @"\";

            if (Directory.Exists(path) == false)
            {
                if (createPath)
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    throw new Exception("[E] Pfad '" + path + "' existiert nicht.");
                }
            }

            return path;
        }

        /// <summary>
        /// <para>DE: Generiert einen eindeutigen Dateinamen.</para>
        /// <para>EN: Creates a unique filename</para>
        /// </summary>
        /// <param name="path">the path</param>
        /// <param name="name">the filename</param>
        /// <param name="ext">the extension</param>
        /// <returns></returns>
        public static string GetUniqueFileName(string path, string fileName, string ext)
        {
            int iNr = 0;
            string sFileName = Path.Combine(path, fileName + ext);

            while (File.Exists(sFileName) == true)
            {
                sFileName = Path.Combine(path, fileName + "_(" + iNr.ToString() + ")" + ext);
                iNr++;
            }

            return sFileName;
        }

        /// <summary>
        /// <para>DE: Generiert einen eindeutigen Dateinamen.</para>
        /// <para>EN: Creates a unique filename</para>
        /// </summary>
        /// <param name="path">the path</param>
        /// <param name="name">the filename</param>
        /// <param name="ext">the extension</param>
        /// <returns></returns>
        public static string GetUniqueFileName(string fnFileName)
        {
            return GetUniqueFileName(Path.GetDirectoryName(fnFileName),
                                      Path.GetFileNameWithoutExtension(fnFileName),
                                      Path.GetExtension(fnFileName));
        }
        #endregion

        #region Execute
        /// <summary>
        /// <para>DE: Startet einen Prozess mit den angegeben Parametern.</para>
        /// <para>EN: Starts a prozess with the given parameters.</para>
        /// </summary>
        /// <param name="fileName">the path of the executeable</param>
        /// <param name="parameters">argument parameters</param>
        public static void Exec(string fileName, string parameters)
        {
            Process processExec = new Process();

            try
            {
                processExec.StartInfo.FileName = fileName;
                processExec.StartInfo.Arguments = parameters;
                processExec.StartInfo.UseShellExecute = false;
                processExec.StartInfo.CreateNoWindow = false;

                processExec.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("Externes Programm kann nicht gestaret werden. Grund :" + System.Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// <para>DE: Startet eine Datei. Das Betriebssystem entscheidet mit welchem Programm.</para>
        /// <para>EN: Starts a file. The operatingsystem decides which programm to run.</para>
        /// </summary>
        /// <param name="fileName">the path of the executeable</param>
        public static void ExecFile(string sFileName)
        {
            Process processExec = new Process();

            try
            {
                processExec.StartInfo.FileName = sFileName;
                processExec.StartInfo.Arguments = "";
                processExec.StartInfo.UseShellExecute = true;
                processExec.StartInfo.CreateNoWindow = false;

                processExec.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("Externes Programm kann nicht gestaret werden. Grund :" + System.Environment.NewLine + ex.Message);
            }
        }

        /// <summary>
        /// <para>DE: Startet einen Prozess mit den angegeben Parametern, und wartet bis dieser beendet ist.</para>
        /// <para>EN: Starts a prozess with the given parameters and wait.</para>
        /// </summary>
        /// <param name="fileName">the path of the executeable</param>
        /// <param name="parameters">argument parameters</param>
        public static int ExecAndWait(string fileName, string parameters)
        {
            Process processExec = new Process();

            try
            {
                processExec.StartInfo.FileName = fileName;
                processExec.StartInfo.Arguments = parameters;
                processExec.StartInfo.UseShellExecute = false;
                processExec.StartInfo.CreateNoWindow = false;
                processExec.Start();

                do
                {
                    Application.DoEvents();

                    // läuft der Child-Process auch noch
                    if (!processExec.HasExited)
                    {
                        // Aktualisiere die Process-Eigenschaften
                        processExec.Refresh();
                    }
                }
                //Wenn der zugeordnete Prozess beendet wurde = true, sonst = false.
                while (!processExec.WaitForExit(20));

                return processExec.ExitCode;

            }
            catch (Exception ex)
            {
                throw new Exception("Externes Programm kann nicht gestaret werden. Grund :" + System.Environment.NewLine + ex.Message);
            }
        }
        #endregion

        #region Notepad
        /// <summary>
        /// <para>DE: Öffnet Text in Notepad ohne eine temp.txt anzulegen.</para>
        /// <para>EN: Opens text in notepad without tempfile.</para>
        /// </summary>
        /// <param name="text">the text</param>
        public static void OpenNotepadWithText(string text)
        {
            Process processExec = new Process();

            System.Windows.Forms.Clipboard.SetDataObject(text, true);
            processExec.StartInfo.FileName = "notepad.exe";
            processExec.StartInfo.UseShellExecute = false;
            processExec.StartInfo.CreateNoWindow = false;

            processExec.Start();

            System.Threading.Thread.Sleep(100);

            SendKeys.Send("^V");
        }

        /// <summary>
        /// <para>DE: Erzeugt eine Datei mit dem angegeben Text und öffnet diese mit NotePad</para>
        /// <para>EN: Creates a file with the given text and opens notepad.</para>
        /// </summary>
        /// <example>
        /// IOHelper.OpenNotepadWithText( "Hello World", "C:\temp\test.txt" );
        /// </example>
        /// <param name="text">the text</param>
        /// <param name="fileName">the filename</param>
        public static void OpenNotepadWithText(string text, string fileName)
        {
            try
            {
                // ** Schreibe Text in Datei
                TextWriter sw = new StreamWriter(fileName, false, Encoding.Unicode);
                sw.Write(text);
                sw.Close();

                //** evtl warten bis die Datei existiert
                for (int n = 0; n < 50; n++)
                {
                    if (File.Exists(fileName))
                        break;
                    System.Threading.Thread.Sleep(100);
                }//for

                // ** NotePad starten
                Exec("notepad.exe", fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("[E] Fehler beim Anzeigen der Datei " + fileName + " mit NotePad.exe\n\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Excel
        /// <summary>
        /// <para>DE: Startet ein DataGrid in Excel</para>
        /// <para>EN: Start a datagrid in excel</para>
        /// </summary>
        /// <param name="grid">the datagrid</param>
        /// <param name="outputFileName">the outputfilename</param>
        public static void StartGridDataInExcel(DataGridView grid, string outputFileName)
        {
            if (File.Exists(outputFileName))
            {
                outputFileName = GetUniqueFileName(Path.GetDirectoryName(outputFileName), Path.GetFileNameWithoutExtension(outputFileName), Path.GetExtension(outputFileName));
            }

            using (StreamWriter MyFile = new StreamWriter(outputFileName, false, Encoding.UTF8))
            {
                string head = "";

                for (int x = 0; x < grid.ColumnCount; x++)
                {
                    head += grid.Columns[x].HeaderText.ToQuoteString('"') + ";";
                }

                MyFile.WriteLine(head);

                for (int i = 0; i < grid.RowCount; i++)
                {
                    //-string stLine = "";
                    StringBuilder sbLine = new StringBuilder();

                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                    {
                        if (grid.Rows[i].Cells[j].Value != null)
                        {
                            string value = grid.Rows[i].Cells[j].Value.ToString();
                            //value = value.Replace( "\n", "<LF>" );                  // Excel kann so eine Datei einlesen -> also lassen
                            value = value.Replace("\r", "\n");                        // Das #13 ist für excel trotzdem ein Sonderzeichen -> \n
                            
                            if (!value.IsNumeric())                                   // bei Zahlen nicht
                                value = value.ToQuoteString('"');
                            sbLine.Append(value);
                            sbLine.Append(';');

                            //-stLine = stLine + grid.Rows[i].Cells[j].Value.ToString().Replace( ";", " " ) + ";";
                        }
                        else
                        {
                            sbLine.Append(grid.Rows[i].Cells[j].Value);
                            sbLine.Append(';');

                            //-stLine = stLine + grid.Rows[i].Cells[j].Value + ";";
                        }
                    }

                    MyFile.WriteLine(sbLine.ToString());
                    //-MyFile.WriteLine( stLine );
                }
            }

            IOHelper.ExecFile(outputFileName);
        }

        /// <summary>
        /// <para>DE: Startet ein DataTable in Excel</para>
        /// <para>EN: Start a datatable in excel</para>
        /// </summary>
        /// <param name="grid">the datatable</param>
        /// <param name="outputFileName">the outputfilename</param>
        public static void StartDataTableInExcel(DataTable datatable, string outputFileName)
        {
            StartDataTableInExcel(datatable, outputFileName, true, true, true);
        }

        /// <summary>
        /// <para>DE: Startet ein DataTable in Excel</para>
        /// <para>EN: Start a datatable in excel</para>
        /// </summary>
        /// <param name="datatable">the datatable</param>
        /// <param name="outputFileName">the outputfilename</param>
        /// <param name="printColumnNames">true=with rowheaders</param>
        /// <param name="printStringQuotes">true=quote strings</param>
        /// <param name="printSemicolonOnLineEnd">true=print semicolon at the end of line</param>
        public static void StartDataTableInExcel(DataTable datatable, string outputFileName,
            bool printColumnNames,
            bool printStringQuotes,
            bool printSemicolonAtLineEnd)
        {
            if (File.Exists(outputFileName))
            {
                outputFileName = GetUniqueFileName(Path.GetDirectoryName(outputFileName), Path.GetFileNameWithoutExtension(outputFileName), Path.GetExtension(outputFileName));
            }

            using (StreamWriter MyFile = new StreamWriter(outputFileName, false, Encoding.UTF8))
            {
                string head = "";

                if (printColumnNames)
                {
                    for (int x = 0; x < datatable.Columns.Count; x++)
                    {
                        head += datatable.Columns[x].Caption.ToQuoteString('"') + ";";
                    }

                    MyFile.WriteLine(head);
                }

                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    StringBuilder sbLine = new StringBuilder();

                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {
                        if (datatable.Rows[i][j] != null)
                        {
                            string value = datatable.Rows[i][j].ToString();
                            value = value.Replace("\r", "\n");                      

                            if (printStringQuotes)
                                // bei Zahlen nicht
                                if (!value.IsNumeric())
                                    value = value.ToQuoteString('"');

                            sbLine.Append(value);
                            sbLine.Append(';');
                        }
                        else
                        {
                            sbLine.Append(datatable.Rows[i][j]);
                            sbLine.Append(';');
                        }
                    }

                    if (printSemicolonAtLineEnd)
                        MyFile.WriteLine(sbLine.ToString());
                    else
                        MyFile.WriteLine(sbLine.Remove(sbLine.Length - 1, 1));
                }
            }

            IOHelper.ExecFile(outputFileName);
        }
        #endregion
    }
}
