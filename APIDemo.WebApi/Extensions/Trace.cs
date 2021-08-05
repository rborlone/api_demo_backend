using System;
using System.Text;

namespace GlobalErrorHandling.Extensions
{
    /// <summary>
    /// Recibe el trace para trabajar el Serilog.
    /// </summary>
    public sealed class Trace
    {
        private static readonly Trace _instance = new Trace();

        private Trace()
        {

        }

        public static Trace Instance => _instance;

        public string generaTrace()
        {
            StringBuilder sb = new StringBuilder();
            DateTime fecha = DateTime.Now;
            string sfec = fecha.ToString();
            sfec = sfec.Replace("/", "");
            sfec = sfec.Replace(":", "");
            sfec = sfec.Replace(" ", "");
            sb.Append("CCS");
            sb.Append(sfec);
            return sb.ToString();
        }

        public string generaTrace(string controller, string metodo)
        {
            StringBuilder sb = new StringBuilder();
            DateTime fecha = DateTime.Now;
            string sfec = fecha.ToString();
            sfec = sfec.Replace("/", "");
            sfec = sfec.Replace(":", "");
            sfec = sfec.Replace(" ", "");
            sb.Append("CCS");
            sb.Append(controller);
            sb.Append(metodo);
            sb.Append(sfec);
            return sb.ToString();
        }

        public string Truncate(string s, int length)
        {
            string result;

            if (string.IsNullOrEmpty(s) || s.Length <= length)
            {
                result = s;
            }
            else
            {
                if (length <= 0)
                {
                    result = string.Empty;
                }
                else
                {
                    result = s.Substring(0, length);
                }
            }

            return result;
        }

    }
}
