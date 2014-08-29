namespace UsersAndRoles
{
    using System;
    using System.Linq;

    internal class UsersAndRoles
    {
        private const string DefaultRoleName = "Admins";

        private static void Main()
        {
            using (var databaseContext = new SecurityModelContainer())
            {
                var result = AddUserTransaction(databaseContext, "Pesho", "taina");
                Console.WriteLine(result);
            }
        }

        private static string AddUserTransaction(
            SecurityModelContainer databaseContext, 
            string username, 
            string password)
        {
            using (var tramsactopm = databaseContext.Database.BeginTransaction())
            {
                try
                {
                    var defaultRole = databaseContext.RoleSet.FirstOrDefault(role => role.Name == DefaultRoleName)
                                      ?? CreateRole(databaseContext, DefaultRoleName);

                    defaultRole.User.Add(new User { Username = username, Password = password });
                    databaseContext.SaveChanges();
                    tramsactopm.Commit();
                    return "Transaction was successful!";
                }
                catch (Exception ex)
                {
                    tramsactopm.Rollback();
                    return string.Format("Transaction was roll backed! The following error occurred: {0}", ex.Message);
                }
            }
        }

        private static Role CreateRole(SecurityModelContainer databaseContext, string role)
        {
            return databaseContext.RoleSet.Add(new Role { Name = role });
        }
    }
}