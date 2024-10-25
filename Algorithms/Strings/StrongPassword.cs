using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Strings;

public class StrongPassword
{

    /// <summary>
    /// Return the minimum number of characters to make the password strong with criteria
    /// Its length is at least 6
    /// It contains at least one digit.
    /// It contains at least one lowercase English character.
    /// It contains at least one uppercase English character.
    /// It contains at least one special character. The special characters are: !@#$%^&*()-+
    /// </summary>
    public static int minimumNumber(int n, string password)
    {
        bool isD=false, isL=false, isU=false, isS=false;
        var specials = new HashSet<char>{'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'};
        
        for(int i=0; i<password.Length; i++){
            if(!isD && char.IsDigit(password[i])){
                isD = true;
            }
            if(!isL && char.IsLower(password[i])){
                isL = true;
            }
            if(!isU && char.IsUpper(password[i])){
                isU = true;
            }
            if(!isS && specials.Contains(password[i])){
                isS = true;
            }
        }
        
        var flags = new List<bool>{ isD, isL, isU, isS }.Count(x => x == false);
        
        return flags > 6-password.Length ? flags : 6-password.Length;
    }

/*
5
A98#+
*/

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        string password = Console.ReadLine();
        int answer = StrongPassword.minimumNumber(n, password);
        Console.WriteLine(answer);
        Console.Read();
    }

}
