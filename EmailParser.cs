using EAGetMail;
using Newtonsoft.Json;
using System.Globalization;

namespace EmailParser
{
    public static class EmailParser
    {
        public static void ParseEmail()
        {
            try
            {
                // Create a folder named "inbox" under current directory
                // to save the email retrieved.
                string localInbox = string.Format("{0}\\inbox", Directory.GetCurrentDirectory());
                // If the folder is not existed, create it.
                if (!Directory.Exists(localInbox))
                {
                    Directory.CreateDirectory(localInbox);
                }

                // Create app password in Google account
                // https://support.google.com/accounts/answer/185833?hl=en
                // Gmail IMAP4 server is "imap.gmail.com"
                //TODO Create a config to store credentials
                MailServer oServer = new("imap.gmail.com", "hirebirhan@gmail.com", "tjuvdjclwozgrjiz", ServerProtocol.Imap4)
                {
                    SSLConnection = true,
                    Port = 993
                };
                MailClient oClient = new("TryIt");
                GetMailInfosParamType filter = new()
                {
                    GetMailInfosOptions = GetMailInfosOptionType.All,
                    
                };
                filter.DateRange.SINCE = DateTime.Now.AddMinutes(-5);

                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos(filter);
                Console.WriteLine("Total {0} email(s)\r\n", infos.Length);
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);

                    // Receive email from IMAP4 server
                    Mail oMail = oClient.GetMail(info);
                    Attachment attachmentFile = oMail.Attachments.FirstOrDefault();
                    attachmentFile.SaveAs($"{Directory.GetCurrentDirectory()}/{attachmentFile.Name}", true);
                    var data = File.ReadAllText(attachmentFile.Name);
                    var ParsedData = JsonConvert.DeserializeObject<VesselReportDto>(data);
                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                    // Generate an unqiue email file name based on date time.
                    string fileName = _generateFileName(i + 1);
                    string fullPath = string.Format("{0}\\{1}", localInbox, fileName);

                    // Save email to local disk
                    oMail.SaveAs(fullPath, true);
                    // Mark email as deleted from IMAP4 server.
                    // oClient.Delete(info);
                }

                // Quit and expunge emails marked as deleted from IMAP4 server.
                oClient.Quit();
                // oClient.Close();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }
        // Generate an unqiue email file name based on date time
        static string _generateFileName(int sequence)
        {
            DateTime currentDateTime = DateTime.Now;
            return string.Format("{0}-{1:000}-{2:000}.eml", currentDateTime.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")), currentDateTime.Millisecond, sequence);
        }
    }
}
