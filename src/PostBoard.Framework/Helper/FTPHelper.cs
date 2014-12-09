using System.IO;
using System.Net;

namespace PostBoard.Framework.Helper
{
    public static class FTPHelper
    {

        public static void DownloadFile(string userName, string password, string ftpFilePathAndName, string localFilePathAndName)
        {
            //http://msdn.microsoft.com/en-us/library/ms229711(v=vs.110).aspx

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePathAndName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(userName, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (FileStream fs = new FileStream(localFilePathAndName, FileMode.Create))
                {
                    response.GetResponseStream().CopyTo(fs);
                }
            }
        }

        public static void DeleteFile(string userName, string password, string ftpFilePathAndName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePathAndName);

            request.Method = WebRequestMethods.Ftp.DeleteFile;

            // This example assumes the FTP site uses anonymous log-on.
            request.Credentials = new NetworkCredential(userName, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }

        public static bool CheckIfFileExsists(string userName, string password, string ftpFilePathAndName)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePathAndName);

            request.Method = WebRequestMethods.Ftp.GetFileSize;

            // This example assumes the FTP site uses anonymous log-on.
            request.Credentials = new NetworkCredential(userName, password);

            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void UploadFile(string userName, string password, string localFilePathAndName, string ftpFilePathAndName)
        {
            if (CheckIfFileExsists(userName, password, ftpFilePathAndName))
            {
                DeleteFile(userName, password, ftpFilePathAndName);
            }

            FileInfo objFile = new FileInfo(localFilePathAndName);

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePathAndName);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            request.KeepAlive = false;

            // Set the data transfer type.
            request.UseBinary = true;

            // Set content length
            request.ContentLength = objFile.Length;

            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous log-on.
            request.Credentials = new NetworkCredential(userName, password);

            // Set buffer size
            int intBufferLength = 16 * 1024;
            byte[] objBuffer = new byte[intBufferLength];

            // Opens a file to read
            using (FileStream objFileStream = objFile.OpenRead())
            {
                // Get Stream of the file
                using (Stream objStream = request.GetRequestStream())
                {
                    int len = 0;
                    while ((len = objFileStream.Read(objBuffer, 0, intBufferLength)) != 0)
                        objStream.Write(objBuffer, 0, len);

                    objStream.Close();
                    objFileStream.Close();
                }
            }
        }

    }
}
