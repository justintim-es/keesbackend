using Microsoft.AspNetCore.Identity;

namespace backend
{
public static class ApplicationDbInitializer
{
    public static void SeedUsers(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByEmailAsync("keesprive770@hotmail.com").Result==null)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "keesprive770@hotmail.com",
                Email = "keesprive770@hotmail.com"
            };

            IdentityResult result = userManager.CreateAsync(user, "Keschees32!").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }       
    }   
}
}