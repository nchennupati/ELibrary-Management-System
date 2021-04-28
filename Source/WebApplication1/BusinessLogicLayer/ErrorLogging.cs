using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BusinessLogicLayer
{
    /// <summary>
    /// Class containg error logging methods
    /// </summary>
    public class ErrorLogging
    {
        /// <summary>
        /// Method to log error
        /// </summary>
        /// <param name="error"></param>
        #region Function to Log Error
        public void LogError(string error)
        {

            string folder = @"D:\ErrorLogs";
           
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string fileName = folder+@"\ErrorLog_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(error+" Time: "+DateTime.Now.ToString()+Environment.NewLine);
            streamWriter.Close();
            fileStream.Close();
        }
        #endregion
    }
}
