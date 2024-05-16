using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LMS.External.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.External.ScheduledTasks
{
   public class Backup : IScheduledTask
   {
       private readonly IServiceScopeFactory _scopeFactory;
       public IConfiguration Configuration { get; }

        public string Schedule => "0 2 * * *";

        public Backup(IServiceScopeFactory scopeFactory, IConfiguration configuration)
       {
           _scopeFactory = scopeFactory;
           Configuration = configuration;

       }
        public async Task Invoke(CancellationToken cancellationToken)
        {
            await BackUpAsync("C:\\temp");
        }
        public async System.Threading.Tasks.Task BackUpAsync(string path)
        {
            try
            {
                //string filesToDelete = @"*Backup_*.bak";   // Only delete DOC files containing "DeleteMe" in their filenames
                string[] fileList = System.IO.Directory.GetFiles(path);
                foreach (string file in fileList)
                {
                    var time = File.GetCreationTime(file);
                    if(time < DateTime.Now.AddDays(-6))
                        System.IO.File.Delete(file);
                }
                var datetime = DateTime.UtcNow;

                var backupPath = Path.Combine(path,
                    "Backup_" + datetime.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss") + ".bak");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    string commandText =
                        $@"BACKUP DATABASE [{connection.Database}] TO DISK = N'{backupPath}' WITH NOFORMAT, INIT, NAME = N'{connection.Database}-Full Database Backup'"; //, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                    connection.Open();
                    //connection.InfoMessage += Connection_InfoMessage;
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                await BackUpAsync("C:\\temp");
            }

        }


    }
}
