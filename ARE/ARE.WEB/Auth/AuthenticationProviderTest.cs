using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace ARE.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity(new List<Claim> {
                new Claim("FirsName","Alberto"),
                new Claim("LastName", "Meza"),
                new Claim(ClaimTypes.Name, "alberto@hotmail.com"),
                new Claim(ClaimTypes.Role,"Testikjh")
                

            }, authenticationType: "prueba");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));

        }
    }
}

