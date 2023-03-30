using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using Newtonsoft.Json;
using System.Globalization;
using System;
using System.Net.Mail;
using EAGetMail;
using MailKit.Security;
using Org.BouncyCastle.Utilities;

namespace EmailParser
{
    public static class EmailParser
    {
        // Generate an unqiue email file name based on date time
        static string _generateFileName(int sequence)
        {
            DateTime currentDateTime = DateTime.Now;
            return string.Format("{0}-{1:000}-{2:000}.eml", currentDateTime.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")), currentDateTime.Millisecond, sequence);
        }
        public static void ParseEmail()
        {
            // create an ImapClient instance
            using (var client = new ImapClient())
            {
                // connect to the IMAP server and authenticate
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("hirebirhan@gmail.com", "tjuvdjclwozgrjiz");

                var items = MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId;
                // set the date range for messages to fetch
                DateTime cutoff = DateTime.Now.AddMinutes(-10);
                var query = SearchQuery.SentSince(cutoff);
                client.Inbox.Open(FolderAccess.ReadOnly);

                // search for all messages
                var results = client.Inbox.Search(SearchQuery.All.And(SearchQuery.SentSince(cutoff)));
                var messages = client.Inbox.Fetch(results, items);

                // retrieve and process each message
                foreach (var message in messages)
                {
                    // download the full message
                    MimeMessage mimeMessage = client.Inbox.GetMessage(message.UniqueId);

                    // check if the message has attachments
                    if (mimeMessage.Attachments.Count() > 0)
                    {
                        Console.WriteLine("Subject: {0}", mimeMessage.Subject);

                        // process the attachments
                        foreach (var attachment in mimeMessage.Attachments)
                        {
                            // check if the attachment is a JSON file
                            try
                            {
                                // read the attachment into a string
                                string json = string.Empty;
                                using (var stream = new MemoryStream())
                                {
                                    var part = (MimePart)attachment;
                                    part.Content.DecodeTo(stream);
                                    stream.Seek(0, SeekOrigin.Begin);
                                    using (var reader = new StreamReader(stream))
                                    {
                                        json = reader.ReadToEnd();
                                    }
                                }

                                // deserialize the JSON into an object
                                VesselReportDto emailData = JsonConvert.DeserializeObject<VesselReportDto>(json);

                                // process the email data as needed
                                Console.WriteLine("version: {0}", emailData.version);
                                Console.WriteLine("report_recipient: {0}", emailData.report_recipient);
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                    }
                }

                // disconnect from the server
                client.Disconnect(true);
            }
        }
    }
}
