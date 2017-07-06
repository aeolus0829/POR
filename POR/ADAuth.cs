using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System;

/// <summary>
/// 回傳目前使用者的各種AD資訊
/// 
/// 限制
/// 執行時需需加入 windows ad
/// 針對 windows form 設計
/// 
/// 使用順序：
/// GetDomainUserID->GetDomainUserName->GetGroupLists->SearchInGroups
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
        public string[] allowADGroups { get; set; }

        string domainName = "Motorpro-sbs";

        public string GetDomainUserID()
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

        public string GetDomainUserName(string domainUsers)
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

        internal bool checkInGroups(List<string> userGroups, string[] groupList)
        {
            bool inGroup = false;

            foreach (string g in userGroups)
            {
                if (groupList.Contains(g))
                {
                    inGroup = true;
                    break; // 只要其中一個群組符合條件即可
                }
            }
            return inGroup;

        }
    }
}