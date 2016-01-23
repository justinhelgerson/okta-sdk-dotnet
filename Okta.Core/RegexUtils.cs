﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Okta.Core
{
    /// <summary>
    /// Regular Expressions utilities
    /// </summary>
    public class RegexUtilities
    {
        //private const string EMAIL_REGEX = @"(?:(?:\r\n)?[ \t])*(?:(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*)|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*:(?:(?:\r\n)?[ \t])*(?:(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*)(?:,\s*(?:(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*|(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)*\<(?:(?:\r\n)?[ \t])*(?:@(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*(?:,@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*)*:(?:(?:\r\n)?[ \t])*)?(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|""(?:[^\""\r\\]|\\.|(?:(?:\r\n)?[ \t]))*""(?:(?:\r\n)?[ \t])*))*@(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*)(?:\.(?:(?:\r\n)?[ \t])*(?:[^()<>@,;:\\"".\[\] \000-\031]+(?:(?:(?:\r\n)?[ \t])+|\Z|(?=[\[""()<>@,;:\\"".\[\]]))|\[([^\[\]\r\\]|\\.)*\](?:(?:\r\n)?[ \t])*))*\>(?:(?:\r\n)?[ \t])*))*)?;\s*)";

        private const string EMAIL_REGEX = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static bool IsValidEmail(string strIn)
        {
            //var emailRegex = new Regex(EMAIL_REGEX.Replace(Environment.NewLine, ""));
            var emailRegex = new Regex(EMAIL_REGEX, RegexOptions.IgnoreCase);
            bool bIsValidEmail = emailRegex.IsMatch(strIn);
            return bIsValidEmail;
        }

    }
}
