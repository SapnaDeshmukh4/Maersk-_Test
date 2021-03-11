using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPIMearsk
{
    public class SortManagercs
    {
        public int[] Sortelements(APIRequest request)
        {
            if (request != null)
            {
                string pathString = Environment.CurrentDirectory;
                string MyFileFolder = Path.Combine(pathString, "MyFile");
                System.IO.Directory.CreateDirectory(MyFileFolder);
                var myUniqueFileName = request.JobId;
                if (request.JobId == null)
                {
                    myUniqueFileName = $@"{Guid.NewGuid()}.txt";
                    if (request.JobId == null)
                    {
                        request.JobId = myUniqueFileName;
                    }
                }
                string Json = JsonSerializer.Serialize<APIRequest>(request);
                pathString = System.IO.Path.Combine(MyFileFolder, myUniqueFileName);
                if (!System.IO.File.Exists(pathString))
                {
                    using (StreamWriter w = File.AppendText(pathString))
                    {
                        SortManagercs.AppendLog(Json, w);
                    }
                }
            }
            Array.Sort(request.Array);
            return request.Array;
        }

        public AllAPIResponse AllElements()
        {
            string pathString = Environment.CurrentDirectory;
            string MyFileFolder = Path.Combine(pathString, "MyFile");
            AllAPIResponse allAPIResponse = new AllAPIResponse();
            string[] files;
            if (Directory.Exists(MyFileFolder))
            {
                foreach (string txtName in Directory.GetFiles(MyFileFolder, @"*.txt", SearchOption.TopDirectoryOnly))
                {
                    using (StreamReader sr = new StreamReader(txtName))
                    {
                        string temp = null;
                        APIResponse response = new APIResponse();
                        temp = sr.ReadToEnd();
                        response = JsonSerializer.Deserialize<APIResponse>(temp);
                        //response.sb.AppendLine(txtName.ToString());
                        //response.sb.AppendLine("= = = = = =");
                        //response.sb.Append(sr.ReadToEnd());
                        //response.sb.AppendLine();
                        //response.sb.AppendLine();
                        allAPIResponse.lstaPIResponses.Add(response);
                    }
                }
            }
            return allAPIResponse;
        }

        public APIResponse BiJobId(string jobid)
        {
            string pathString = Environment.CurrentDirectory;
            string MyFileFolder = Path.Combine(pathString, "MyFile");
            APIResponse response = new APIResponse();
            if (Directory.Exists(MyFileFolder))
            {
                foreach (string txtName in Directory.GetFiles(MyFileFolder, @"*.txt", SearchOption.TopDirectoryOnly))
                {
                    if (txtName.Split('\\').LastOrDefault() == jobid)
                    {
                        using (StreamReader sr = new StreamReader(txtName))
                        {
                            string temp = null;
                            temp = sr.ReadToEnd();
                            response = JsonSerializer.Deserialize<APIResponse>(temp);
                        }
                        return response;
                    }
                }
            }
            return response;
        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                //txtWriter.Write("\r\nLog Entry : ");
                //txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                //txtWriter.WriteLine("  :");
                txtWriter.WriteLine("{0}", logMessage);
                //txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public static WriteTextFile(APIRequest request)
        //{
        //    string pathString = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        //    System.IO.Directory.CreateDirectory(pathString);
        //    string Json = JsonSerializer.Serialize<APIRequest>(request);
        //    var myUniqueFileName = $@"{Guid.NewGuid()}.txt";
        //    pathString = System.IO.Path.Combine(pathString, myUniqueFileName);
        //    if (!System.IO.File.Exists(pathString))
        //    {
        //        using (System.IO.FileStream fs = System.IO.File.Create(pathString))
        //        {
        //            for (byte i = 0; i < 100; i++)
        //            {
        //                fs.WriteByte(i);
        //            }
        //        }
        //    }
        //    else
        //    {
        //    }
        //}
    }
}
