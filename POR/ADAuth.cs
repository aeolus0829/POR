using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System;

/// <summary>
/// 回傳目前使用者的各種AD資訊
/// 
/// 使用順序：
/// GetDomainUserName->GetUserID->GetGroupLists->SearchInGroups
/// 
/// 註：
/// 1 System.DirectoryServices.AccountManagement 必須用加入參考(Add reference)的方式
/// 光用 using 是不夠的
/// 
/// 2 allowADGroups, domainName 按需求修改
/// 
/// </summary>


namespace ADAuth
{
    public class Auth
    {
        string[] allowADGroups = {
            "Domain Admins",
            "17101人資課",
            "19101總經理室"
        };

        string domainName = "Motorpro-sbs";

        public string GetDomainUserName()
        {
            string domainUserName = Environment.UserName;
            return domainUserName;
        }

        public bool SearchInGroups(List<string> groupList)
        {
            bool inGroup = false;

            foreach (string g in allowADGroups)
            {
                if (groupList.Contains(g))
                {
                    inGroup = true;
                    break; // 只要其中一個群組符合條件即可
                }
            }
            return inGroup;

        }

        public string GetDomainName(string domainUsers)
        {
            return domainName;
        }

        public string GetUserID(string domainUsers)
        {
            UserPrincipal user = UserPrincipal.Current;
            return user.ToString();
        }

        public List<string> GetGroupLists(string userName)
        {
            var pc = new PrincipalContext(ContextType.Domain, domainName);
            var src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc);
            var result = new List<string>();
            src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
            return result;
        }

        private bool IsInRole(string domain, string username, string password, string role)
        {
            using (var context = new PrincipalContext(ContextType.Domain, domain, username, password))
            {
                GroupPrincipal group = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, role);
                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
                return IsInGroup(user, group);
            }
        }

        private bool IsInGroup(Principal principal, GroupPrincipal group)
        {
            if (principal.IsMemberOf(group))
                return true;

            foreach (var g in principal.GetGroups())
            {
                if (IsInGroup(g, group))
                    return true;
            }

            return false;
        }
    }
}