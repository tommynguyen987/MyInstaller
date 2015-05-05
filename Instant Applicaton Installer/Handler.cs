namespace InstantApplicationInstaller
{
    public class Handler
    {
        public static System.Data.DataTable LoadData(int type, string appName)
        {
            DataBase db = new DataBase();
            System.Data.DataTable dt = new System.Data.DataTable();

            switch (type)
            {
                case 2:
                    string strSQLAdvance = "SELECT * FROM ApplicationInfo WHERE AppType = 'Advanced'" + (appName == "" ? "" :  (" AND AppName LIKE '%" + appName + "%'"));                   
                    dt = db.LoadTry(strSQLAdvance);
                    break;
                case 3:
                    string strSQLAdded = "SELECT * FROM ApplicationInfo" + (appName == "" ? "" : (" WHERE AppName LIKE '%" + appName + "%'"));                   
                    dt = db.LoadTry(strSQLAdded);
                    break;
                default:
                    string strSQLBasic = "SELECT * FROM ApplicationInfo WHERE AppType = 'Basic'" + (appName == "" ? "" : (" AND AppName LIKE '%" + appName + "%'"));                   
                    dt = db.LoadTry(strSQLBasic);
                    break;
            }

            return dt;
        }

        public static System.Data.DataTable LoadDataByID(string id)
        {
            DataBase db = new DataBase();            
            string strSQLAdded = "SELECT * FROM ApplicationInfo WHERE ID = '" + id + "'";
            System.Data.DataTable dt = db.LoadTry(strSQLAdded);            
            
            return dt;
        }

        public static System.Data.DataTable LoadDataByName(string appName)
        {
            DataBase db = new DataBase();
            string strSQLAdded = "SELECT * FROM ApplicationInfo" + (appName == "" ? "" : (" WHERE AppName LIKE '%" + appName + "%'"));
            System.Data.DataTable dt = db.LoadTry(strSQLAdded);

            return dt;
        }

        public static void AddItem(ApplicationInfo appInfo)
        {
            DataBase db = new DataBase();                    
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            strBuilder.Append("INSERT INTO ApplicationInfo (\"ID\",\"AppName\",\"AppPath\",\"AppType\") ");
            strBuilder.AppendFormat("VALUES ('{0}', '{1}', '{2}', '{3}')", appInfo.ID, appInfo.AppName, appInfo.AppPath, appInfo.AppType);
            db.UpdateTry(strBuilder.ToString());
        }            

        public static void RemoveItem(string id)            
        {
            DataBase db = new DataBase();
            string strSQL = "DELETE FROM ApplicationInfo WHERE ID = '" + id + "'";
            db.UpdateTry(strSQL);
        }

        public static void UpdateItem(ApplicationInfo appInfo)
        {
            DataBase db = new DataBase();
            string strSQL = "UPDATE ApplicationInfo SET AppName = '" + appInfo.AppName + "', AppType = '"+ appInfo.AppType +"'  WHERE ID = '" + appInfo.ID + "'";
            db.UpdateTry(strSQL);
        }

        public static string GetLastItem(string input, char splitter)
        {
            string[] arrValues = input.Split(splitter);
            return arrValues[arrValues.Length - 1];
        }

        public static string RemoveExtension(string input)
        {
            string []ext = { ".exe", ".msi", ".rar", ".zip" };
            string temp = "";
            foreach (var item in ext)
            {
                if (input.Contains(item))
                {
                    temp = item;
                    break;                    
                }   
            }
            if (temp != "")
            {
                return input.Replace(temp, "");    
            }
            return input;
        }

        public static void DeleteFiles(string SourceFolder)
        {
            try
            {
                if (!System.IO.Directory.Exists(SourceFolder))
                    return;                
                
                System.IO.Directory.Delete(SourceFolder, true);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error while performing deleting operation." + System.Environment.NewLine + ex.Message, "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }  
        }

        //Copy file by binary
        public static void CopyBinaryFile(string fromFilePath, string toFilePath)
        {
            System.IO.Stream s1 = System.IO.File.Open(fromFilePath, System.IO.FileMode.Open);
            System.IO.Stream s2 = System.IO.File.Open(toFilePath, System.IO.FileMode.Create);

            System.IO.BinaryReader f1 = new System.IO.BinaryReader(s1);
            System.IO.BinaryWriter f2 = new System.IO.BinaryWriter(s2);

            while (true)
            {
                byte[] buf = new byte[10240];   //10240
                int sz = f1.Read(buf, 0, 10240);
                if (sz <= 0)
                    break;
                f2.Write(buf, 0, sz);
                if (sz < 10240)
                    break; // eof reached
            }
            f1.Close();
            f2.Close();
        }

        //Copy file by stream
        public static void CopyFromFile(string fromFilePath, System.IO.Stream toStream)
        {
            using (System.IO.Stream fromStream = System.IO.File.OpenRead(fromFilePath))
                CopyStream(fromStream, toStream);
        }

        public static void CopyToFile(System.IO.Stream fromStream, string toFilePath)
        {
            using (System.IO.Stream toStream = System.IO.File.Create(toFilePath))
                CopyStream(fromStream, toStream);
        }

        /// <summary>
        /// CopyStream simply copies 'fromStream' to 'toStream'
        /// </summary>
        public static int CopyStream(System.IO.Stream fromStream, System.IO.Stream toStream)
        {
            byte[] buffer = new byte[10240]; //8192
            int totalBytes = 0;
            for (; ; )
            {
                int count = fromStream.Read(buffer, 0, buffer.Length);
                if (count == 0)
                    break;
                toStream.Write(buffer, 0, count);
                totalBytes += count;
            }
            return totalBytes;
        }

        public static void CopyFileStream(string fromFilePath, string toFilePath)
        {
            using (System.IO.FileStream objFromStream = System.IO.File.Open(fromFilePath, System.IO.FileMode.Open))
            {
                int bufferSize = 1024 * 1024;
                using (System.IO.FileStream objToStream = new System.IO.FileStream(toFilePath, System.IO.FileMode.Create))
                {
                    objToStream.SetLength(objFromStream.Length);
                    int bytesRead = -1;
                    byte[] bytes = new byte[bufferSize];

                    while ((bytesRead = objFromStream.Read(bytes, 0, bufferSize)) > 0)
                    {
                        objToStream.Write(bytes, 0, bytesRead);
                    }                                
                }                
            } 
        }

        public static void CopyFiles(string SourceFolder, string DestFolder)
        {
            string[] sDirs = null;
            string sFolder = null;
            string[] sFiles = null;
            string sFileName = null;

            try
            {                
                if (System.IO.Directory.Exists(SourceFolder))
                {
                    // Subfolders
                    sDirs = System.IO.Directory.GetDirectories(SourceFolder);
                    foreach (string sDir in sDirs)
                    {
                        sFolder = sDir.Replace(SourceFolder + "\\", string.Empty);
                        CopyFiles(sDir, DestFolder + "\\" + sFolder);
                    }

                    sFiles = System.IO.Directory.GetFiles(SourceFolder);
                    foreach (string sFile in sFiles)
                    {
                        sFileName = sFile.Replace(SourceFolder + "\\", string.Empty);
                        if (!System.IO.Directory.Exists(DestFolder))
                            System.IO.Directory.CreateDirectory(DestFolder);
                        System.IO.File.Copy(SourceFolder + "\\" + sFileName, DestFolder + "\\" + sFileName, true);                        
                    }
                }
                else
                {
                    if (System.IO.File.Exists(SourceFolder))
                    {
                        sFileName = GetLastItem(SourceFolder, '\\');
                        if (!System.IO.Directory.Exists(DestFolder))
                            System.IO.Directory.CreateDirectory(DestFolder);
                        System.IO.File.Copy(SourceFolder, DestFolder + "\\" + sFileName, true);                        
                    }
                }                           
            }
            catch {}            
        }

        [System.ThreadStatic]
        private static System.Random rnd;
        public static int GetRandomInteger()
        {
            if (rnd == null) rnd = new System.Random((int)System.DateTime.Now.Ticks);
            return System.Math.Abs(System.Convert.ToInt32(rnd.Next(int.MaxValue - 10000) + 10000));            
        }
    }

    public class ApplicationInfo
    {
        public string ID { get ; set; }
        public string AppName { get; set; }
        public string AppPath { get; set; }
        public AppTypes AppType { get; set; }
    }

    public enum AppTypes 
    {
        Basic = 1,
        Advanced = 2
    }
}
