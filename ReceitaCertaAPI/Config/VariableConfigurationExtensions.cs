using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace ReceitaCertaAPI.Config
{
    using ReceitaCertaAPI.Middlewares;
    public static class VariableConfigurationExtensions
    {
        public static string GetKeyVaultName(this IConfiguration _) => GetVariable("KEY_VAULT_NAME");

        #region Métodos de classe
        private static string GetVariable(string variableName)
        {
            try
            {
                var variable = Environment.GetEnvironmentVariable(variableName);
                return variable ?? throw new HttpResponseException(
                    new BadRequestObjectResult($"Erro ao ler a variável de ambiente, verifique se {variableName} foi definida."));
            }
            catch (Exception)
            {
                throw new HttpResponseException(new BadRequestObjectResult($"Erro ao ler a variável de ambiente {variableName},  permissão negada."));
            }
        }
    }
    #endregion
}
