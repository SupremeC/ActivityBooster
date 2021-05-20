using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using System.Net.Mail;
using System.Net;
using System.IO;
using SyntheticProductivityBooster.MouseJiggler.Properties;

namespace SyntheticProdBooster.MailerNS
{
    public class Mailer    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        CancellationTokenSource? source;
        private bool doNotSendEmailOnWeekend = true;
        private static readonly Random rand = new();
        public bool IsRunning { get; set; }
        private List<TimeSpan> intervals = new();
        private List<string> emailTitles = new();
        private List<string> emailBodies = new();

        public void StartMailing(int number, int startHour = 6, int endHour = 17)
        {
            StopMailing();
            IsRunning = true;
            Task.Run(async delegate { StartMailingBaby(number, startHour, endHour); });
        }

        public void StopMailing()
        {
            if (IsRunning && source!=null && !source.IsCancellationRequested)
            {
                logger.Info("Stopping Mailer");
                source.Cancel(false);
                IsRunning = false;
            }
        }

        private async Task StartMailingBaby(int number, int startHour, int endHour)
        {
            source = new CancellationTokenSource();
            logger.Info("Starting Mailer");
            while (true)
            {
                intervals = Times(number, startHour, endHour).ToList();
                Shuffle<TimeSpan>(intervals);
                emailBodies = GetEmailBodies();
                emailTitles = GetEmailTitles();
                foreach (var interval in intervals)
                {
                    source.Token.ThrowIfCancellationRequested();
                    var t = Task.Run(async delegate {
                        if (!ShouldISendEmailsNow(startHour, endHour, out var delay)) {
                            source.Token.ThrowIfCancellationRequested();
                            logger.Debug($"sleeping until business hours at {startHour} ({delay.Hours}h{delay.Minutes}m)");
                            await Task.Delay((int)delay.TotalMilliseconds, source.Token);
                            logger.Debug($"Im awake again! Waiting for {interval.TotalSeconds}s to next email interval");
                        }
                        source.Token.ThrowIfCancellationRequested();
                        logger.Debug($"waiting {interval.TotalSeconds}s for next email run");
                        await Task.Delay((int)interval.TotalMilliseconds, source.Token);
                        source.Token.ThrowIfCancellationRequested();
                        await Task.Run(() =>
                        {
                            SendEmail();
                        });

                    });
                    try
                    {
                        t.Wait(source.Token);
                    }
                    catch (OperationCanceledException e)
                    {
                        logger.Info($"Mailing cancelled");
                        logger.Trace(e);
                        return;
                    }
                    catch(Exception e)
                    {
                        logger.Error(e);
                        return;
                    }
                }
            }
        }

        private void SendEmail()
        {
            logger.Debug("About to send email");
            var toAddress = new MailAddress(Settings.Default.EmailTo, "David Berglund");


            using (MailMessage mail = new())
            {
                mail.From = new MailAddress(Settings.Default.EmailFrom);
                mail.To.Add(toAddress);
                mail.Subject = emailTitles[rand.Next(0, emailTitles.Count-1)];
                mail.Body = emailBodies[rand.Next(0, emailBodies.Count - 1)];
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Settings.Default.EmailFrom, Settings.Default.EmailPwd);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            logger.Info($"Sent email to '{Settings.Default.EmailTo}'");
        }

        private bool ShouldISendEmailsNow(int startHour, int endHour, out TimeSpan delayInMilliSeconds)
        {
            delayInMilliSeconds = new TimeSpan(0);
            var now = DateTime.Now;
            var nowHour = DateTime.Now.Hour;
            if (startHour <= nowHour && endHour > nowHour)
                return true;

            DateTime nextDay = new DateTime(now.Year, now.Month, now.Day, startHour, 0, 0).AddDays(1);
            if (doNotSendEmailOnWeekend)
                while (IsWeekend(nextDay))
                    nextDay = nextDay.AddDays(1);
            delayInMilliSeconds = nextDay.Subtract(now);
            return false;
        }

        private static IEnumerable<TimeSpan> Times(int number, int startHour = 6, int endHour = 17)
        {
            var total = new TimeSpan(endHour - startHour, 0, 0).TotalSeconds;
            int minInterval = (int)Math.Ceiling(total / 1500);
            int maxInterval = (int)Math.Floor(total / (number / 2));
            maxInterval = (minInterval >= maxInterval) ? minInterval + 1 : maxInterval;

            var list = new List<TimeSpan>();
            while (list.Count < number)
            {
                list.Add(new TimeSpan(0,0, rand.Next(minInterval, maxInterval)));
            }
            return list;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }

        private List<string> GetEmailTitles()
        {
            try
            {
                return File.ReadAllText("MailStuff\\titles.txt").Split(Environment.NewLine).ToList();
            }
            catch(Exception x)
            {
                logger.Error(x);
                return null;
            }
        }

        private List<string> GetEmailBodies()
        {
            try
            {
                return File.ReadAllText("MailStuff\\body.txt").Split("¤").ToList();
            }
            catch (Exception x)
            {
                logger.Error(x);
                return null;
            }
        }
    }
}