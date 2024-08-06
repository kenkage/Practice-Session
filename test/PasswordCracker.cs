using System;
namespace test
{
	public class PasswordCrackers
	{
        public static string PasswordCracker(List<string> passwords, string loginAttempt)
        {
            // Initialize a map to store the result for each substring
            Dictionary<string, string> memo = new Dictionary<string, string>();
            string result = CanFormPassword(passwords, loginAttempt, memo);
            return result == null ? "WRONG PASSWORD" : result.Trim();
        }

        private static string CanFormPassword(List<string> passwords, string target, Dictionary<string, string> memo)
        {
            if (target.Length == 0) return "";
            if (memo.ContainsKey(target)) return memo[target];

            foreach (string password in passwords)
            {
                if (target.StartsWith(password))
                {
                    string suffix = target.Substring(password.Length);
                    string result = CanFormPassword(passwords, suffix, memo);
                    if (result != null)
                    {
                        memo[target] = password + " " + result;
                        return memo[target];
                    }
                }
            }
            memo[target] = null;
            return null;
        }
    }

    public class Program4
    {
        //public static void Main(string[] args)
        //{
            //List<string> passwords1 = new List<string> { "abra", "ka", "dabra" };
            //string loginAttempt1 = "abrakadabra";
            //Console.WriteLine(PasswordCrackers.PasswordCracker(passwords1, loginAttempt1));  // Output: "abra ka dabra"

            //List<string> passwords2 = new List<string> { "ka", "abra" };
            //string loginAttempt2 = "kaabra";
            //Console.WriteLine(PasswordCrackers.PasswordCracker(passwords2, loginAttempt2));  // Output: "ka abra"

            //List<string> passwords3 = new List<string> { "ab", "ba", "abab" };
            //string loginAttempt3 = "aba";
            //Console.WriteLine(PasswordCrackers.PasswordCracker(passwords3, loginAttempt3));  // Output: "WRONG PASSWORD"
        //}
    }
}

